using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRaze.Data
{
    public class AdminDao
    {
        public void KillGame(uint gameId)
        {
            using var cn = Db.GetOpenConnection();
            using var cmd = new MySqlCommand("sp_kill_game", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_gameId", gameId);
            cmd.ExecuteNonQuery();
        }

        public void AddPlayer(string username, string email, string passwordHash, bool isAdmin)
        {
            using var cn = Db.GetOpenConnection();
            using var cmd = new MySqlCommand("sp_admin_add_player", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_username", username);
            cmd.Parameters.AddWithValue("@p_email", email);
            cmd.Parameters.AddWithValue("@p_passwordhash", passwordHash);
            cmd.Parameters.AddWithValue("@p_isAdmin", isAdmin ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        public void UpdatePlayer(uint playerId, string username, string email, string passwordHash, bool isAdmin, bool isLocked)
        {
            using var cn = Db.GetOpenConnection();
            using var cmd = new MySqlCommand("sp_admin_update_player", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_playerId", playerId);
            cmd.Parameters.AddWithValue("@p_username", username);
            cmd.Parameters.AddWithValue("@p_email", email);
            cmd.Parameters.AddWithValue("@p_passwordhash", passwordHash);
            cmd.Parameters.AddWithValue("@p_isAdmin", isAdmin ? 1 : 0);
            cmd.Parameters.AddWithValue("@p_isLocked", isLocked ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        public void DeletePlayer(uint playerId)
        {
            using var cn = Db.GetOpenConnection();
            using var cmd = new MySqlCommand("sp_admin_delete_player", cn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@p_playerId", playerId);
            cmd.ExecuteNonQuery();
        }
    }
}