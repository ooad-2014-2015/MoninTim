using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FanShop.Baza
{
    public class BazaPodataka {
        private MySqlConnection con;

        private void Connect() {
            string username = "root";
            string password = "";
            string db = "ooadprojekat";
            string connectionString = "server=localhost;user=" + username + ";pwd=" + password + ";database=" + db;

            con = new MySqlConnection(connectionString);
            con.Open();
        }

        private void Disconnect()
        {
            con.Close();
        }

        // ==============>> INSERTI:

        public bool UnesiDres(string id, string slika, string cijena) {
            Connect();
            string s = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "");
            s = s.Replace("\\", "\\\\");
           
            
            slika =slika.Replace(s, "");
            
            MySqlCommand insertQuery = new MySqlCommand(
                  "INSERT INTO dresovi (id, slika, cijena) VALUES (" + 
                     id + ", '" + slika + "', " + cijena + ");", con);

            
            insertQuery.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        public bool UnesiSal(string id, string slika, string cijena)
        {
            Connect();
            string s = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "");
            s = s.Replace("\\", "\\\\");


            slika = slika.Replace(s, "");

            MySqlCommand insertQuery = new MySqlCommand(
                 "INSERT INTO salovi (id, slika, cijena) VALUES (" +
                     id + ", '" + slika + "', " + cijena + ");", con);

            insertQuery.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        public bool UnesiKapu(string id, string slika, string cijena)
        {
            Connect();

            string s = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "");
            s = s.Replace("\\", "\\\\");


            slika = slika.Replace(s, "");
            MySqlCommand insertQuery = new MySqlCommand(
                "INSERT INTO kape (id, slika, cijena) VALUES (" +
                    id + ", '" + slika + "', " + cijena + ");", con);

            insertQuery.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        public bool UnesiPrivjesak(string id, string slika, string cijena)
        {
            Connect();
            string s = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "");
            s = s.Replace("\\", "\\\\");


            slika = slika.Replace(s, "");
            MySqlCommand insertQuery = new MySqlCommand(
                "INSERT INTO privjesci (id, slika, cijena) VALUES (" +
                    id + ", '" + slika + "', " + cijena + ");", con);

            insertQuery.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        public int UnesiUKatalog(string tip)
        {
            Connect();

            MySqlCommand insertQuery = new MySqlCommand(
                "INSERT INTO katalog (tip) VALUES (" +
                    "'" + tip + "');", con);

            insertQuery.ExecuteNonQuery();

            MySqlCommand maxQuery = new MySqlCommand(
                "SELECT Max(id) AS 'id' FROM katalog;", con);
            MySqlDataReader r = maxQuery.ExecuteReader();

            r.Read();
            int id = Int32.Parse(r.GetString("id"));

            Disconnect();
            return id;
        }

        public bool UnesiUArhivu(string id, string kolicina, string datum)
        {
            Connect();
            string tip = "";

            MySqlCommand tipcmd = new MySqlCommand("SELECT tip FROM katalog WHERE id=" + id, con);
            MySqlDataReader r = tipcmd.ExecuteReader();
            r.Read();
            tip = r.GetString("tip");
            r.Close();

            MySqlCommand insertQuery = new MySqlCommand(
                "INSERT INTO arhiva (id, kolicina, datum, tip) VALUES (" +
                    id + ", " + kolicina + ", " + datum + ", '" + tip + "');", con);

            insertQuery.ExecuteNonQuery();
            Disconnect();
            return true;
        }

        public int UnesiUposlenika(string username, string password, string ime_prezime)
        {
            Connect();

            MySqlCommand insertQuery = new MySqlCommand(
                "INSERT INTO uposlenici (username, password, ime_prezime) VALUES (" +
                    "'" + username + "', '" + password + "', '" + ime_prezime + "');", con);

            insertQuery.ExecuteNonQuery();
            int id = 0;
            insertQuery = new MySqlCommand(
                "SELECT id FROM uposlenici WHERE username = '" + username + "';", con);
            MySqlDataReader r = insertQuery.ExecuteReader();
            r.Read();
            id = r.GetInt32("id");
            
            Disconnect();
            return id;
        }

        public int UnesiClana(string username, string password, string email, string adresa, string broj_telefona)
        {
            Connect();

            MySqlCommand insertQuery = new MySqlCommand(
                "INSERT INTO korisnici (username, password, email, adresa, broj_telefona) VALUES (" +
                    "'" + username + "', '" + password + "', '" + email + "', '" + adresa + "', '" + broj_telefona + "');", con);

            insertQuery.ExecuteNonQuery();
            int id = 0;
            insertQuery = new MySqlCommand(
                "SELECT id FROM korisnici WHERE username = '" + username + "';", con);
            MySqlDataReader r = insertQuery.ExecuteReader();
            r.Read();
            id = r.GetInt32("id");

            Disconnect();
            return id;
        }

        public void UnesiULog(string id, string akcija, string datum)
        {
            Connect();

            MySqlCommand insertQuery = new MySqlCommand(
                "INSERT INTO log (id, akcija, datum) VALUES (" +
                    id + ", '" + akcija + "', " + datum + ");", con);

            insertQuery.ExecuteNonQuery();
            Disconnect();
        }

        // ==============>> SELECTI:

        public string DajApsolutniPath(string slika)
        {
            return Environment.CurrentDirectory.Replace(@"bin\Debug", "") + @"\" + slika;
        }

        public List<Dres> VratiDresove()
        {
            Connect();
            List<Dres> lista = new List<Dres>();
            MySqlCommand query = new MySqlCommand("SELECT * FROM dresovi;", con);
            MySqlDataReader r = query.ExecuteReader();

            while (r.Read())
            {
                Dres d = new Dres();
                d.Cijena = r.GetDecimal("cijena");
                d.Id = r.GetInt32("id");
                d.Slika = DajApsolutniPath(r.GetString("slika"));
                d.Velicine = r.GetString("velicine");

                lista.Add(d);
            }

            r.Close();
            Disconnect();
            return lista;
        }

        public List<Sal> VratiSalove()
        {
            Connect();
            List<Sal> lista = new List<Sal>();
            MySqlCommand query = new MySqlCommand("SELECT * FROM salovi;", con);
            MySqlDataReader r = query.ExecuteReader();

            while (r.Read())
            {
                Sal s = new Sal();
                s.Id = r.GetInt32("id");
                s.Slika = DajApsolutniPath(r.GetString("slika"));
                s.Cijena = r.GetDecimal("cijena");

                lista.Add(s);
            }

            r.Close();
            Disconnect();
            return lista;
        }

        public List<Kapa> VratiKape()
        {
            Connect();
            List<Kapa> lista = new List<Kapa>();
            MySqlCommand query = new MySqlCommand("SELECT * FROM kape;", con);
            MySqlDataReader r = query.ExecuteReader();

            while (r.Read())
            {
                Kapa k = new Kapa();
                k.Cijena = r.GetDecimal("cijena");
                k.Id = r.GetInt32("id");
                k.Slika = DajApsolutniPath(r.GetString("slika"));
                k.Velicine = r.GetString("velicine");

                lista.Add(k);
            }

            r.Close();
            Disconnect();
            return lista;
        }

        public List<Privjesak> VratiPrivjeske()
        {
            Connect();
            List<Privjesak> lista = new List<Privjesak>();
            MySqlCommand query = new MySqlCommand("SELECT * FROM privjesci;", con);
            MySqlDataReader r = query.ExecuteReader();

            while (r.Read())
            {
                Privjesak p = new Privjesak();
                p.Cijena = r.GetDecimal("cijena");
                p.Id = r.GetInt32("id");
                p.Slika = DajApsolutniPath(r.GetString("slika"));

                lista.Add(p);
            }

            r.Close();
            Disconnect();
            return lista;
        }

        public List<Moderator> VratiUposlenike()
        {
            Connect();
            List<Moderator> lista = new List<Moderator>();
            MySqlCommand query = new MySqlCommand("SELECT * FROM uposlenici;", con);
            MySqlDataReader r = query.ExecuteReader();

            while (r.Read())
            {
                Moderator m = new Moderator();
                m.Ime_prezime = r.GetString("ime_prezime");
                m.Id = r.GetInt32("id");
                m.Username = r.GetString("username");
                m.Password = r.GetString("password");

                lista.Add(m);
            }

            r.Close();
            Disconnect();
            return lista;
        }


        public List<Arhiva> UcitajArhivuDan()
        {
            Connect();
            List<Arhiva> arhiva = new List<Arhiva>();
            MySqlCommand query = new MySqlCommand("SELECT id, Sum(kolicina), tip FROM arhiva  WHERE DATE(datum) = CURDATE() GROUP BY id ORDER BY Sum(Kolicina) DESC LIMIT 10;", con);
            MySqlDataReader r = query.ExecuteReader(); 

            while (r.Read())
                arhiva.Add(new Arhiva(r.GetInt32("id"), r.GetInt32("Sum(kolicina)"), r.GetString("tip")));

            r.Close();
            Disconnect();


            return arhiva;
        }
        public List<Arhiva> UcitajArhivuMjesec()
        {
            Connect();
            List<Arhiva> arhiva = new List<Arhiva>();
            MySqlCommand query = new MySqlCommand("SELECT id, Sum(kolicina), tip FROM arhiva  WHERE YEAR(DATE(datum)) = YEAR(CURDATE()) AND MONTH(DATE(datum)) = MONTH(CURDATE()) GROUP BY id ORDER BY Sum(kolicina) DESC LIMIT 10;", con);
            MySqlDataReader r = query.ExecuteReader();

            while (r.Read() )
            {
                arhiva.Add(new Arhiva(r.GetInt32("id"), r.GetInt32("Sum(kolicina)"), r.GetString("tip")));
               
            }

            r.Close();
            Disconnect();


            return arhiva;
        }
        public List<Arhiva> UcitajArhivuGodina()
        {
            Connect();
            List<Arhiva> arhiva = new List<Arhiva>();
            MySqlCommand query = new MySqlCommand("SELECT id, Sum(kolicina), tip FROM arhiva WHERE YEAR(DATE(datum)) = YEAR(CURDATE()) GROUP BY id ORDER BY Sum(kolicina) DESC LIMIT 10;", con);
            MySqlDataReader r = query.ExecuteReader();

            
            while (r.Read()){
                arhiva.Add(new Arhiva(r.GetInt32("id"), r.GetInt32("Sum(kolicina)"), r.GetString("tip")));
    
            }

            r.Close();
            Disconnect();


            return arhiva;
        }


        public List<Proizvod> VratiZaDanas()
        {
            List<Proizvod> lista = new List<Proizvod>();
            List<Arhiva> arh = UcitajArhivuDan();
            for (int i = 0; i < arh.Count; i++ )
                lista.Add(DajProizvodPoIdu((arh[i].ID).ToString(), arh[i].Tip));

            return lista;
        }

        public List<Proizvod> VratiZaMjesec()
        {
            List<Proizvod> lista = new List<Proizvod>();
            List<Arhiva> arh = UcitajArhivuMjesec();
            for (int i = 0; i < arh.Count; i++)
                lista.Add(DajProizvodPoIdu((arh[i].ID).ToString(), arh[i].Tip));

            return lista;

        }
        public List<Proizvod> VratiZaGodinu()
        {
            List<Proizvod> lista = new List<Proizvod>();
            List<Arhiva> arh = UcitajArhivuGodina();
            for (int i = 0; i < arh.Count; i++)
                lista.Add(DajProizvodPoIdu((arh[i].ID).ToString(), arh[i].Tip));

            return lista;
        }

   

        private Proizvod DajProizvodPoIdu(string id, string tip)
        {
            Connect();
            string tabela = "";
            
            if (tip == "d") tabela = "dresovi";
            else if (tip == "s") tabela = "salovi";
            else if (tip == "k") tabela = "kape";
            else if (tip == "p") tabela = "privjesci";

            MySqlCommand query = new MySqlCommand("SELECT * FROM " + tabela + " WHERE id=" + id + ";", con);
            MySqlDataReader r = query.ExecuteReader();
            r.Read();

            if (tip == "d")
            {
                Dres d = new Dres();
                d.Cijena = r.GetDecimal("cijena");
                d.Id = r.GetInt32("id");
                d.Slika = DajApsolutniPath(r.GetString("slika"));
                d.Velicine = r.GetString("velicine");

                return d;
            }
            else if (tip == "s")
            {
                Sal s = new Sal();
                s.Id = r.GetInt32("id");
                s.Slika = DajApsolutniPath(r.GetString("slika"));
                s.Cijena = r.GetDecimal("cijena");

                return s;
            }
            else if (tip == "k")
            {
                Kapa k = new Kapa();
                k.Cijena = r.GetDecimal("cijena");
                k.Id = r.GetInt32("id");
                k.Slika = DajApsolutniPath(r.GetString("slika"));
                k.Velicine = r.GetString("velicine");

                return k;
            }
            else if (tip == "p")
            {
                Privjesak p = new Privjesak();
                p.Cijena = r.GetDecimal("cijena");
                p.Id = r.GetInt32("id");
                p.Slika = DajApsolutniPath(r.GetString("slika"));

                return p;
            }

            return null; // da ne bude warninga
        }

        public List<Proizvod> VratiKatalog()
        {
            Connect();
            List<Proizvod> lista = new List<Proizvod>();
            MySqlCommand query = new MySqlCommand("SELECT * FROM katalog;", con);
            MySqlDataReader r = query.ExecuteReader();

            while (r.Read())
                lista.Add(DajProizvodPoIdu(r.GetString("id"), r.GetString("tip")));

            r.Close();
            Disconnect();
            return lista;
        }

        public Clan VratiClana(string username, string password)
        {
            Connect();
            Clan c = new Clan();
            MySqlCommand query = new MySqlCommand("SELECT * FROM korisnici WHERE username = '" + username + "' AND password ='" + password +"';", con);
            MySqlDataReader r = query.ExecuteReader();

            while (r.Read())
            {
                 c.Id = r.GetInt32("id");
                c.Username = r.GetString("username");
                c.Password = r.GetString("password");
                c.Adresa = r.GetString("adresa");
                c.Broj_telefona = r.GetString("broj_telefona");
                c.Email = r.GetString("email");

            }

            r.Close();
            Disconnect();
            return c;
        }

        public List<Clan> VratiClanove()
        {
            Connect();
            List<Clan> lista = new List<Clan>();
            MySqlCommand query = new MySqlCommand("SELECT * FROM korisnici;", con);
            MySqlDataReader r = query.ExecuteReader();

            while (r.Read())
            {
                Clan c = new Clan();

                c.Id = r.GetInt32("id");
                c.Username = r.GetString("username");
                c.Password = r.GetString("password");
                c.Adresa = r.GetString("adresa");
                c.Broj_telefona = r.GetString("broj_telefona");
                c.Email = r.GetString("email");

                lista.Add(c);
            }

            r.Close();
            Disconnect();
            return lista;
        }

        public List<string> VratiLog()
        {
            Connect();
            List<string> lista = new List<string>();

            MySqlCommand query = new MySqlCommand("SELECT * FROM log;", con);
            MySqlDataReader r = query.ExecuteReader();

            while (r.Read())
            {
                string id = r.GetString("id");
                string akcija = r.GetString("akcija");
                string datum = r.GetString("datum");

                lista.Add(id + " - " + akcija + " (" + datum + ")");
            }

            Disconnect();
            return lista;
        }

        public int VratiIDModeratora(string username)
        {
            Connect();
            int id = 0;

            MySqlCommand query = new MySqlCommand("SELECT id FROM uposlenici WHERE username='" + username + "';", con);
            MySqlDataReader r = query.ExecuteReader();
            r.Read();

            id = r.GetInt32("id");
            Disconnect();
            return id;
        }
        // ==============>> DROPOVI:

        public void ObrisiDres(string id, int ugasi_konekciju = 1)
        {
            Connect();
            MySqlCommand delquery = new MySqlCommand("DELETE FROM dresovi WHERE id = " + id + ";", con);
            delquery.ExecuteNonQuery();
            IzbrisiIzArhive(id);
            if (ugasi_konekciju == 1) Disconnect();
        }

        public void ObrisiSal(string id, int ugasi_konekciju = 1)
        {
            Connect();
            MySqlCommand delquery = new MySqlCommand("DELETE FROM salovi WHERE id = " + id + ";", con);
            delquery.ExecuteNonQuery();
            IzbrisiIzArhive(id);
            if (ugasi_konekciju == 1) Disconnect();
        }

        public void ObrisiKapu(string id, int ugasi_konekciju = 1)
        {
            Connect();
            MySqlCommand delquery = new MySqlCommand("DELETE FROM kape WHERE id = " + id + ";", con);
            delquery.ExecuteNonQuery();
            IzbrisiIzArhive(id);
            if (ugasi_konekciju == 1) Disconnect();
        }

        public void ObrisiPrivjesak(string id, int ugasi_konekciju = 1)
        {
            Connect();
            MySqlCommand delquery = new MySqlCommand("DELETE FROM privjesci WHERE id = " + id + ";", con);
            delquery.ExecuteNonQuery();
            IzbrisiIzArhive(id);
            if (ugasi_konekciju == 1) Disconnect();
        }

        public void ObrisiUposlenika(string id)
        {
            Connect();
            MySqlCommand delquery = new MySqlCommand("DELETE FROM uposlenici WHERE id = " + id + ";", con);
            delquery.ExecuteNonQuery();
            Disconnect();
        }

        public void ObrisiClana(string id)
        {
            Connect();
            MySqlCommand delquery = new MySqlCommand("DELETE FROM korisnici WHERE id = " + id + ";", con);
            delquery.ExecuteNonQuery();
            Disconnect();
        }

        public void ObrisiProizvod(string id)
        {
            Connect();
            MySqlCommand query = new MySqlCommand("SELECT tip FROM katalog WHERE id = " + id + ";", con);
            MySqlDataReader r = query.ExecuteReader();
            r.Read();
            string tip = r.GetString("tip");

            switch (tip)
            {
                case "d":
                    this.ObrisiDres(id, 0);
                    break;
                case "s":
                    this.ObrisiSal(id, 0);
                    break;
                case "k":
                    this.ObrisiKapu(id, 0);
                    break;
                case "p":
                    this.ObrisiPrivjesak(id, 0);
                    break;
                default:
                    // validacija? viđat ćemo
                    break;
            }

            r.Close();

            MySqlCommand delquery = new MySqlCommand("DELETE FROM katalog WHERE id = " + id + ";", con);
            delquery.ExecuteNonQuery();

            Disconnect();
        }

        // ==============>> MISC:

        public bool ProvjeriLoginPodatke(string user, string pw, bool uposlenik) // ako uposlenik == false onda je korisnik
        {
            Connect();
            MySqlCommand selectQuery = new MySqlCommand("SELECT password FROM " + ((uposlenik) ? "uposlenici" : "korisnici") + " WHERE username='" + user + "';", con);
            MySqlDataReader r = selectQuery.ExecuteReader();
            r.Read();

            if (r.HasRows == false) return false; // fallback ako nema tog usernamea
            else
                return r.GetString("password") == pw;
        }

        private void IzbrisiIzArhive(string id)
        {
            MySqlCommand delquery = new MySqlCommand("DELETE FROM arhiva WHERE id = " + id + ";", con);
            delquery.ExecuteNonQuery();
        }
    }
}
