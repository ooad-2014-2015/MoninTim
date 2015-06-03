using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FkHepekMobile.Resources
{
    public class Tim
    {
        public string Naziv { get; set; }
		public string Odigrano { get; set; }
        public string Pobjeda { get; set; }
        public string Nerijeseno { get; set; }
        public string Izgubljeno { get; set; }
        public string Poeni { get; set; }

        public override string ToString()
        {
            return String.Format("{0, -12}{1,-4}{2,-4}{3,-4}{4,-4}{5,-4}", Naziv, Odigrano, Pobjeda, Nerijeseno, Izgubljeno, Poeni);
        }
    }

}
