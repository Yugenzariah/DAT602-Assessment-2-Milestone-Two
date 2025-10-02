DROP DATABASE IF EXISTS theraze;
CREATE DATABASE theraze;
USE theraze;

-- =========================================================
-- Tables
-- =========================================================

CREATE TABLE Player (
  PlayerID       INT UNSIGNED NOT NULL AUTO_INCREMENT,
  Username       VARCHAR(40)  NOT NULL UNIQUE,
  Email          VARCHAR(120) NOT NULL UNIQUE,
  PasswordHash   CHAR(64)     NOT NULL,
  IsAdmin        TINYINT(1)   NOT NULL DEFAULT 0,
  IsLocked       TINYINT(1)   NOT NULL DEFAULT 0,
  LoginAttempts  SMALLINT     NOT NULL DEFAULT 0,
  Highscore      INT          NOT NULL DEFAULT 0,
  LastOnline     DATETIME     NULL,
  CreatedAt      TIMESTAMP    NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (PlayerID)
);

CREATE TABLE Game (
  GameID     INT UNSIGNED NOT NULL AUTO_INCREMENT,
  Name       VARCHAR(60)  NOT NULL,
  Status     VARCHAR(20)  NOT NULL DEFAULT 'Waiting', -- Waiting | Running | Killed | Finished
  StartedAt  DATE         NULL,
  EndedAt    DATE         NULL,
  PRIMARY KEY (GameID)
);

CREATE TABLE Tile (
  TileID   INT UNSIGNED NOT NULL AUTO_INCREMENT,
  GameID   INT UNSIGNED NOT NULL,
  X        SMALLINT     NOT NULL,
  Y        SMALLINT     NOT NULL,
  TileType VARCHAR(50)  NOT NULL DEFAULT 'Floor',
  PRIMARY KEY (TileID),
  CONSTRAINT uq_Tile_Game_Coord UNIQUE (GameID, X, Y),
  CONSTRAINT fk_Tile_Game       FOREIGN KEY (GameID) REFERENCES Game(GameID)
    ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE PlayerGame (
  PlayerGameID INT UNSIGNED NOT NULL AUTO_INCREMENT,
  PlayerID     INT UNSIGNED NOT NULL,
  GameID       INT UNSIGNED NOT NULL,
  Score        INT          NOT NULL DEFAULT 0,
  HP           SMALLINT     NOT NULL DEFAULT 100,
  CurrentTileID INT UNSIGNED NULL,  -- null until placed
  IsTurn       TINYINT(1)   NOT NULL DEFAULT 0,
  JoinedAt     DATE         NOT NULL,
  PRIMARY KEY (PlayerGameID),
  CONSTRAINT fk_PG_Player FOREIGN KEY (PlayerID) REFERENCES Player(PlayerID)
    ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT fk_PG_Game   FOREIGN KEY (GameID)  REFERENCES Game(GameID)
    ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT fk_PG_Tile   FOREIGN KEY (CurrentTileID) REFERENCES Tile(TileID)
    ON DELETE SET NULL ON UPDATE CASCADE
  -- Ensure only one player per tile (NULL allowed multiple times)
);
CREATE UNIQUE INDEX uq_PG_Tile ON PlayerGame (CurrentTileID);

CREATE TABLE Item (
  ItemID   INT UNSIGNED NOT NULL AUTO_INCREMENT,
  Name     VARCHAR(60)  NOT NULL,
  ItemType VARCHAR(60)  NOT NULL,             -- e.g. Health, Junk, Weapon, Quest
  Points   SMALLINT     NOT NULL DEFAULT 0,   -- scoring +/-
  Weight   DECIMAL(5,2) NOT NULL DEFAULT 0.0,
  PRIMARY KEY (ItemID)
);

CREATE TABLE Inventory (
  InventoryID  INT UNSIGNED NOT NULL AUTO_INCREMENT,
  PlayerGameID INT UNSIGNED NOT NULL,
  ItemID       INT UNSIGNED NOT NULL,
  Quantity     SMALLINT     NOT NULL DEFAULT 1,
  PRIMARY KEY (InventoryID),
  CONSTRAINT uq_Inv_PG_Item UNIQUE (PlayerGameID, ItemID),
  CONSTRAINT fk_Inv_PG   FOREIGN KEY (PlayerGameID) REFERENCES PlayerGame(PlayerGameID)
    ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT fk_Inv_Item FOREIGN KEY (ItemID)       REFERENCES Item(ItemID)
    ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE TABLE TileItem (
  TileItemID INT UNSIGNED NOT NULL AUTO_INCREMENT,
  TileID     INT UNSIGNED NOT NULL,
  ItemID     INT UNSIGNED NOT NULL,
  Quantity   SMALLINT     NOT NULL DEFAULT 1,
  PRIMARY KEY (TileItemID),
  CONSTRAINT uq_TileItem UNIQUE (TileID, ItemID),
  CONSTRAINT fk_TI_Tile FOREIGN KEY (TileID) REFERENCES Tile(TileID)
    ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT fk_TI_Item FOREIGN KEY (ItemID) REFERENCES Item(ItemID)
    ON DELETE RESTRICT ON UPDATE CASCADE
);

-- Views
CREATE VIEW v_player_locations AS
SELECT pg.PlayerGameID, pg.PlayerID, p.Username, pg.GameID,
       t.TileID, t.X, t.Y, pg.IsTurn
FROM PlayerGame pg
LEFT JOIN Player p ON p.PlayerID = pg.PlayerID
LEFT JOIN Tile t   ON t.TileID   = pg.CurrentTileID;

-- =========================================================
-- Insert Data
-- =========================================================

INSERT INTO Player (Username, Email, PasswordHash, IsAdmin)
VALUES ('yugenzariah', 'yz@example.com', REPEAT('x',60), 1),
       ('mira',        'mira@example.com', REPEAT('y',60), 0),
       ('rory',        'rory@example.com', REPEAT('z',60), 0);

INSERT INTO Game (Name, Status, StartedAt)
VALUES ('Raze-Alpha', 'Running', CURDATE());

-- Items BEFORE TileItem references
INSERT INTO Item (Name, ItemType, Points, Weight) VALUES
('Apple',  'Health',  5,  0.2),
('Medkit', 'Health', 15,  1.0),
('Gem',    'Treasure', 25, 0.5),
('Trap',   'Hazard', -10, 0.3);

-- 5x5 board for Game 1 (Home tile at 0,0)
DELIMITER $$
CREATE PROCEDURE sp_init_board(p_gameId INT UNSIGNED, p_width INT, p_height INT)
BEGIN
  DECLARE x INT DEFAULT 0;
  DECLARE y INT DEFAULT 0;
  SET x = 0;
  WHILE x < p_width DO
    SET y = 0;
    WHILE y < p_height DO
      INSERT INTO Tile(GameID, X, Y, TileType)
      VALUES (p_gameId, x, y, IF(x=0 AND y=0,'Home','Floor'));
      SET y = y + 1;
    END WHILE;
    SET x = x + 1;
  END WHILE;
END$$
DELIMITER ;

CALL sp_init_board(1,5,5);

-- Put some items on tiles (after Tile table is populated)
INSERT INTO TileItem (TileID, ItemID, Quantity)
SELECT t.TileID, i.ItemID, 1
FROM Tile t
JOIN Item i ON ( (i.Name='Gem'  AND t.X=2 AND t.Y=2 AND t.GameID=1)
              OR (i.Name='Trap' AND t.X=1 AND t.Y=1 AND t.GameID=1)
              OR (i.Name='Apple' AND t.X=0 AND t.Y=1 AND t.GameID=1) );

-- Join players to the game - yugenzariah at Home (0,0), mira at (0,1)
INSERT INTO PlayerGame (PlayerID, GameID, Score, HP, CurrentTileID, IsTurn, JoinedAt)
SELECT p.PlayerID, 1, 0, 100, 
       CASE 
         WHEN p.Username = 'yugenzariah' THEN (SELECT TileID FROM Tile WHERE GameID=1 AND X=0 AND Y=0)
         WHEN p.Username = 'mira' THEN (SELECT TileID FROM Tile WHERE GameID=1 AND X=1 AND Y=0)
       END,
       IF(p.Username='yugenzariah',1,0), 
       CURDATE()
FROM Player p
WHERE p.Username IN ('yugenzariah','mira');

-- =========================================================
-- Utility function: get adjacency
-- =========================================================
DELIMITER $$
CREATE FUNCTION fn_is_adjacent(p_fromTile INT UNSIGNED, p_toTile INT UNSIGNED)
RETURNS TINYINT READS SQL DATA DETERMINISTIC
BEGIN
  DECLARE x1 SMALLINT; DECLARE y1 SMALLINT; DECLARE g1 INT UNSIGNED;
  DECLARE x2 SMALLINT; DECLARE y2 SMALLINT; DECLARE g2 INT UNSIGNED;
  SELECT X,Y,GameID INTO x1,y1,g1 FROM Tile WHERE TileID=p_fromTile;
  SELECT X,Y,GameID INTO x2,y2,g2 FROM Tile WHERE TileID=p_toTile;
  IF g1 IS NULL OR g2 IS NULL OR g1 <> g2 THEN
    RETURN 0;
  END IF;
  RETURN IF(ABS(x1-x2)+ABS(y1-y2)=1,1,0);
END$$
DELIMITER ;

-- =========================================================
-- Stored Procedures (12 processes)
-- =========================================================
DELIMITER $$

-- 1) Player login including lockout
CREATE PROCEDURE sp_login_player(
  IN p_username VARCHAR(40),
  IN p_passwordhash CHAR(64),
  OUT p_status VARCHAR(20)       -- 'OK' | 'LOCKED' | 'BADPASS' | 'UNKNOWN'
)
proc_label: BEGIN
  DECLARE v_id INT UNSIGNED; DECLARE v_locked TINYINT; DECLARE v_attempts SMALLINT; DECLARE v_hash CHAR(64);
  SELECT PlayerID, IsLocked, LoginAttempts, PasswordHash
    INTO v_id, v_locked, v_attempts, v_hash
  FROM Player WHERE Username = p_username;

  IF v_id IS NULL THEN
    SET p_status := 'UNKNOWN';
    LEAVE proc_label;
  END IF;

  IF v_locked = 1 THEN
    SET p_status := 'LOCKED';
  ELSE
    IF v_hash = p_passwordhash THEN
      UPDATE Player
         SET LoginAttempts = 0,
             LastOnline = NOW()
       WHERE PlayerID = v_id;
      SET p_status := 'OK';
    ELSE
      SET v_attempts := v_attempts + 1;
      UPDATE Player
         SET LoginAttempts = v_attempts,
             IsLocked = IF(v_attempts >= 5, 1, 0)
       WHERE PlayerID = v_id;
      SET p_status := IF(v_attempts >= 5, 'LOCKED', 'BADPASS');
    END IF;
  END IF;
END$$

-- 2) Player registration (auto-login effect left to app)
CREATE PROCEDURE sp_register_player(
  IN p_username VARCHAR(40),
  IN p_email    VARCHAR(120),
  IN p_passwordhash CHAR(64)
)
BEGIN
  INSERT INTO Player (Username, Email, PasswordHash, IsAdmin, IsLocked, LoginAttempts, Highscore, LastOnline)
  VALUES (p_username, p_email, p_passwordhash, 0, 0, 0, 0, NOW());
END$$

-- 3) Laying out tiles on a board.
CREATE PROCEDURE sp_reset_board(
  IN p_gameId INT UNSIGNED,
  IN p_width INT,
  IN p_height INT
)
BEGIN
  DELETE FROM Tile WHERE GameID = p_gameId;
  CALL sp_init_board(p_gameId, p_width, p_height);
END$$

-- 4) Placing an item on a tile
CREATE PROCEDURE sp_place_item_on_tile(
  IN p_tileId INT UNSIGNED,
  IN p_itemId INT UNSIGNED,
  IN p_qty    SMALLINT
)
BEGIN
  INSERT INTO TileItem (TileID, ItemID, Quantity)
  VALUES (p_tileId, p_itemId, p_qty)
  ON DUPLICATE KEY UPDATE Quantity = Quantity + VALUES(Quantity);
END$$

-- 5) Player movement: move to adjacent, empty tile (and toggle turn)
CREATE PROCEDURE sp_move_player(
  IN p_playerGameId INT UNSIGNED,
  IN p_targetTileId INT UNSIGNED
)
BEGIN
  DECLARE v_from INT UNSIGNED; DECLARE v_ok TINYINT; DECLARE v_game INT UNSIGNED;
  SELECT CurrentTileID, GameID INTO v_from, v_game FROM PlayerGame WHERE PlayerGameID=p_playerGameId;
  IF v_from IS NULL THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT='Player not placed yet'; END IF;

  SET v_ok = fn_is_adjacent(v_from, p_targetTileId);
  IF v_ok = 0 THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT='Illegal move (not adjacent or wrong game)'; END IF;

  -- Make sure that the destination is empty
  IF EXISTS(SELECT 1 FROM PlayerGame WHERE CurrentTileID=p_targetTileId) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT='Tile occupied';
  END IF;

  UPDATE PlayerGame
     SET CurrentTileID = p_targetTileId,
         IsTurn = 0
   WHERE PlayerGameID = p_playerGameId;

  -- Give turn to some other player in same game (simple round-robin)
  UPDATE PlayerGame SET IsTurn=1
  WHERE GameID=v_game AND PlayerGameID<>p_playerGameId
  ORDER BY JoinedAt LIMIT 1;
END$$

-- 6) Game play scoring
CREATE PROCEDURE sp_update_score(
  IN p_playerGameId INT UNSIGNED,
  IN p_delta INT
)
BEGIN
  UPDATE PlayerGame SET Score = Score + p_delta
  WHERE PlayerGameID = p_playerGameId;

  -- Optionally push to Player.Highscore
  UPDATE Player p
  JOIN PlayerGame pg ON pg.PlayerID=p.PlayerID
  SET p.Highscore = GREATEST(p.Highscore, pg.Score)
  WHERE pg.PlayerGameID = p_playerGameId;
END$$

-- 7) Player picks up an item from current tile to inventory (and score from item)
CREATE PROCEDURE sp_pickup_item(
  IN p_playerGameId INT UNSIGNED,
  IN p_itemId INT UNSIGNED,
  IN p_qty SMALLINT
)
BEGIN
  DECLARE v_tile INT UNSIGNED; DECLARE v_points SMALLINT;

  SELECT CurrentTileID INTO v_tile FROM PlayerGame WHERE PlayerGameID=p_playerGameId;
  IF v_tile IS NULL THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT='Player has no tile'; END IF;

  -- Check availability
  IF NOT EXISTS(SELECT 1 FROM TileItem WHERE TileID=v_tile AND ItemID=p_itemId AND Quantity>=p_qty) THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT='Not enough on tile';
  END IF;

  -- Move qty
  UPDATE TileItem SET Quantity = Quantity - p_qty
  WHERE TileID=v_tile AND ItemID=p_itemId;
  DELETE FROM TileItem WHERE TileID=v_tile AND ItemID=p_itemId AND Quantity<=0;

  INSERT INTO Inventory (PlayerGameID, ItemID, Quantity)
  VALUES (p_playerGameId, p_itemId, p_qty)
  ON DUPLICATE KEY UPDATE Quantity = Quantity + VALUES(Quantity);

  -- Scoring from item definition
  SELECT Points INTO v_points FROM Item WHERE ItemID=p_itemId;
  CALL sp_update_score(p_playerGameId, v_points * p_qty);
END$$

-- 8) NPC Item movement (move TileItem to an adjacent tile if empty or the same item)
CREATE PROCEDURE sp_move_tile_item(
  IN p_tileItemId INT UNSIGNED,
  IN p_targetTileId INT UNSIGNED
)
BEGIN
  DECLARE v_srcTile INT UNSIGNED; DECLARE v_item INT UNSIGNED;
  SELECT TileID, ItemID INTO v_srcTile, v_item FROM TileItem WHERE TileItemID=p_tileItemId;

  IF v_srcTile IS NULL THEN SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT='TileItem not found'; END IF;
  IF fn_is_adjacent(v_srcTile, p_targetTileId) = 0 THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT='Illegal NPC move';
  END IF;

  -- Move by merging/upserting 1 unit
  UPDATE TileItem SET Quantity = Quantity - 1 WHERE TileItemID=p_tileItemId;
  DELETE FROM TileItem WHERE TileItemID=p_tileItemId AND Quantity<=0;

  INSERT INTO TileItem (TileID, ItemID, Quantity)
  VALUES (p_targetTileId, v_item, 1)
  ON DUPLICATE KEY UPDATE Quantity = Quantity + 1;
END$$

-- 9) Kill running games
CREATE PROCEDURE sp_kill_game(IN p_gameId INT UNSIGNED)
BEGIN
  UPDATE Game SET Status='Killed', EndedAt=CURDATE() WHERE GameID=p_gameId;
  UPDATE PlayerGame SET IsTurn=0 WHERE GameID=p_gameId;
END$$

-- 10) Admin add new player
CREATE PROCEDURE sp_admin_add_player(
  IN p_username VARCHAR(40),
  IN p_email VARCHAR(120),
  IN p_passwordhash CHAR(64),
  IN p_isAdmin TINYINT
)
BEGIN
  INSERT INTO Player (Username, Email, PasswordHash, IsAdmin, CreatedAt)
  VALUES (p_username, p_email, p_passwordhash, p_isAdmin, NOW());
END$$

-- 11) Admin update player data
CREATE PROCEDURE sp_admin_update_player(
  IN p_playerId INT UNSIGNED,
  IN p_username VARCHAR(40),
  IN p_email VARCHAR(120),
  IN p_passwordhash CHAR(64),
  IN p_isAdmin TINYINT,
  IN p_isLocked TINYINT
)
BEGIN
  UPDATE Player
     SET Username     = p_username,
         Email        = p_email,
         PasswordHash = p_passwordhash,
         IsAdmin      = p_isAdmin,
         IsLocked     = p_isLocked
   WHERE PlayerID = p_playerId;
END$$

-- 12) Admin delete a player
CREATE PROCEDURE sp_admin_delete_player(IN p_playerId INT UNSIGNED)
BEGIN
  DELETE FROM Player WHERE PlayerID=p_playerId;
END$$

DELIMITER ;