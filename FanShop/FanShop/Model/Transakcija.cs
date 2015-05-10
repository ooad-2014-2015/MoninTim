using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanShop.Model
{
    public class Transakcija
    {
        public enum Placanje
        {
            gotovina,
            kartica
        }

        public Korpa korpa
        {
            get;
            set;
        }
        public Placanje nacinPlacanja
        {
            get;
            set;
        }
        public DateTime datum
        {
            get;
            set;
        }

        public void saveToLog()
        {
        }
    }
}
