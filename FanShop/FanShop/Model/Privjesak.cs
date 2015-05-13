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
            return "(" + this.Id + ") PRIVJESAK";
        }
    }
}
