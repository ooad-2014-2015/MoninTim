using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string ukupno = ProracunajPopust(Korpa.UkupnoCijena).ToString();
            string ispis = "";

            foreach (Stavka s in Korpa.Stavke)
            {
                ispis += s.Proizvod.ToString() + "\n";
            }

            return ispis;
        }

        private decimal ProracunajPopust(decimal cijena)
        {
            // if KORISNIK ??
            return cijena + cijena * 2;

            // else gost 
            // return cijena;
        }
    }
}
