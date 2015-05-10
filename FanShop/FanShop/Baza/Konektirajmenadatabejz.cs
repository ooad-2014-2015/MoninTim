using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FanShop
{
    public class Konekcija
    {
        public MySqlConnection con
        {
            get;
            set;
        }
        public void Konektirajmenadatabejz()
        {
            string username = "root";
            string password = "";
            string db = "ooadprojekat";
            string connectionString = "server=localhost;user=" + username + ";pwd=" + password + ";database=" + db;
            con = new MySqlConnection(connectionString);
           
        }

    }
}
