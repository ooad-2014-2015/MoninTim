using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FanShop
{
    public class Kapa :  Proizvod, INotifyPropertyChanged
    {
        private string velicine;

        public string Velicine
        {
            get { return velicine; }
            set { velicine = value; OnPropertyChanged("Velicine"); }
        }

        public override string ToString()
        {
            return "(" + this.Id + ") KAPA";
        }
    }
}
