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

        public Kapa()
        {
            velicine = "";
        }

        public Kapa(Proizvod p)
        {
            this.Id = p.Id;
            this.Cijena = p.Cijena;
            this.Slika = p.Slika;
            velicine = "";
        }

        public string Velicine
        {
            get { return velicine; }
            set { velicine = value; OnPropertyChanged("Velicine"); }
        }

        public override string ToString()
        {
            return Id + " Kapa            " + Cijena + " KM";
        }
            
    }
}
