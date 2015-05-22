using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FanShop
{
    public class Sal : Proizvod, INotifyPropertyChanged
    {
        public override string ToString()
        {
            return Id + " Šal             " + Cijena + " KM";
        }
            

        public Sal()
        {
            
        }

        public Sal(Proizvod p)
        {
            this.Id = p.Id;
            this.Cijena = p.Cijena;
            this.Slika = p.Slika;
        }
    }
}
