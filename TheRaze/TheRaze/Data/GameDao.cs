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
    }
}
