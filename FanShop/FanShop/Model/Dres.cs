using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FanShop
{
    public class Dres : Proizvod, INotifyPropertyChanged
    {
        private string velicine, imeIgraca;

        public string Velicine
        {
            get { return velicine; }
            set { velicine = value; OnPropertyChanged("Velicine"); }
        }

        public string ImeIgraca
        {
            get { return imeIgraca; }
            set { imeIgraca = value; OnPropertyChanged("ImeIgraca"); }
        }

        public override string ToString()
        {
            return "(" + this.Id + ") DRES";
        }
    }
}
