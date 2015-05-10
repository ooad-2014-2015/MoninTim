using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanShop
{
    public class Korpa
    {
        public List<Stavka> listaStavki
        {
            get;
            set;
        }
        public string sifraRacuna
        {
            get;
            set;
        }
        public decimal ukupnoCijena
        {
            get;
            set;
        }
    }
}
