using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FanShop
{
    public class Privjesak : Proizvod, INotifyPropertyChanged
    {
        public override string ToString()
        {
            return Id + " Privjesak " + Cijena + "KM";
        }
            

        public Privjesak()
        {

        }

        public Privjesak(Proizvod p)
        {
            this.Id = p.Id;
            this.Cijena = p.Cijena;
            this.Slika = p.Slika;
        }
    }
}
