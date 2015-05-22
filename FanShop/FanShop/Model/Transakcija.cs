using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime;


namespace FanShop
{
    public class Transakcija
    {
        public enum Placanje
        {
            gotovina,
            kartica
        }

        public Korpa Korpa
        {
            get;
            set;
        }
        public Placanje NacinPlacanja
        {
            get;
            set;
        }
        public DateTime Datum
        {
            get;
            set;
        }

        public void saveToLog()
        {
        }

        public bool Korisnik
        {
            // TODO
            get;
            set;
        }

        private decimal popust = 0.2M;  // 20% za korisnike!
        
        

        // testni racun!!
        public string DajRacun()
        {
            string ukupno = Korpa.UkupnoCijena.ToString();

       
            string rac = "Racun:";
            rac += Environment.NewLine;
            rac += GenerisiBrojRacuna();
            rac += Environment.NewLine;
           
            rac += Environment.NewLine;

            string head = "Kol. BR.Proizvod        Cijena";
           
            rac += head;

            rac += Environment.NewLine;
            
            rac += "__________________________________";
            rac += Environment.NewLine;
            rac += Environment.NewLine;
         
            
            foreach (Stavka s in Korpa.Stavke)
            {
                rac += s.Kolicina + "    " + s.Proizvod.ToString();
                rac += Environment.NewLine;
            }

            rac += "__________________________________";
            rac += Environment.NewLine;
            rac += "Ukupno:                " + ukupno + "  KM";
            rac += Environment.NewLine;
            rac += Environment.NewLine;
            rac += "Datum i vrijeme: " + Environment.NewLine +DateTime.Now;
            rac += Environment.NewLine;
            rac += "Hvala na posjeti."; 

            return rac;
        }

        private decimal ProracunajPopust(decimal cijena)
        {
            // if KORISNIK ??
            return cijena + cijena * 2;

            // else gost 
            // return cijena;
        }

        private int GenerisiBrojRacuna()
        {
             Random random = new Random(); 
             return random.Next(151247, 957296);
        }
    }
}
