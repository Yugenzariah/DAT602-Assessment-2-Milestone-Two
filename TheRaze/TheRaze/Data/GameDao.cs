using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRaze.Data
{
    public class GameDao
    {
        public void MovePlayer(uint playerGameId, uint targetTileId)
        {
            using var cn = Db.GetOpenConnection();
            using var cmd = new MySqlCommand("sp_move_player", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_playerGameId", playerGameId);
            cmd.Parameters.AddWithValue("@p_targetTileId", targetTileId);
            cmd.ExecuteNonQuery();
        }

        public void AddScore(uint playerGameId, int delta)
        {
            using var cn = Db.GetOpenConnection();
            using var cmd = new MySqlCommand("sp_update_score", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_playerGameId", playerGameId);
            cmd.Parameters.AddWithValue("@p_delta", delta);
            cmd.ExecuteNonQuery();
        }

        public void ResetBoard(uint gameId, int width, int height)
        {
            using var cn = Db.GetOpenConnection();
            using var cmd = new MySqlCommand("sp_reset_board", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_gameId", gameId);
            cmd.Parameters.AddWithValue("@p_width", width);
            cmd.Parameters.AddWithValue("@p_height", height);
            cmd.ExecuteNonQuery();
        }

        public void PlaceItemOnTile(uint tileId, uint itemId, short quantity)
        {
            using var cn = Db.GetOpenConnection();
            using var cmd = new MySqlCommand("sp_place_item_on_tile", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_tileId", tileId);
            cmd.Parameters.AddWithValue("@p_itemId", itemId);
            cmd.Parameters.AddWithValue("@p_qty", quantity);
            cmd.ExecuteNonQuery();
        }

        public void PickupItem(uint playerGameId, uint itemId, short quantity)
        {
            using var cn = Db.GetOpenConnection();
            using var cmd = new MySqlCommand("sp_pickup_item", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_playerGameId", playerGameId);
            cmd.Parameters.AddWithValue("@p_itemId", itemId);
            cmd.Parameters.AddWithValue("@p_qty", quantity);
            cmd.ExecuteNonQuery();
        }
    }
}
