using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FanShop
{
   public class Moderator : Osoba
    {

       public int izbroji()
       {
           Konekcija kon = new Konekcija();
           kon.Konektirajmenadatabejz();

           MySqlConnection con = kon.con;
           con.Open();

           int broj = 0;
           MySqlCommand upit = new MySqlCommand("select max(id) from katalog", con);

           MySqlDataReader r = upit.ExecuteReader();

           while (r.Read())
           {
               broj = int.Parse(r.GetString("max(id)"));
           }

           r.Close();

           return broj;
       }

        public void dodajProizvod(Proizvod p)
        {

            Konekcija kon = new Konekcija();
            kon.Konektirajmenadatabejz();

            MySqlConnection con = kon.con;
            con.Open();
            string s = "";

            if (p is Dres)
            {
                MySqlCommand ins = new MySqlCommand("insert into Katalog(tip) values ('" + "d" + "')", con);
                ins.ExecuteNonQuery();
                s += "dresovi";
            }

            else if (p is Kapa)
            {
                MySqlCommand ins = new MySqlCommand("insert into Katalog(tip) values ('" + "k" + "')", con);
                ins.ExecuteNonQuery();
                s+="kape";
            }
            else if (p is Privjesak)
            {
                MySqlCommand ins = new MySqlCommand("insert into Katalog(tip) values ('" + "p" + "')", con);
                ins.ExecuteNonQuery();
                s+="privjesci";
            }
            else if(p is Sal)
            {
                MySqlCommand ins = new MySqlCommand("insert into Katalog(tip) values ('" + "s" + "')", con);
                ins.ExecuteNonQuery();
                s+="privjesci";
            }
            MySqlCommand nova = new MySqlCommand("insert into "+ s + "(id,slika, cijena) values ('" + izbroji() + "','" + p.slika + "','" + p.cijena + "')", con);
                nova.ExecuteNonQuery();

        }
    }
}
