using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheRaze.Data
{
    public static class Db
    {
        // TODO: replace with actual server/user/pw
        private const string ConnStr = "Server=127.0.0.1;Port=3306;Database=theraze;Uid=root;Pwd=Prime_Yugenzariah@23%;SslMode=None;";

        public static MySqlConnection GetOpenConnection()
        {
            var cn = new MySqlConnection(ConnStr);
            cn.Open();
            return cn;
        }
    }
}