using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanShop
{
    public class Gost
    {
        static int p = 1;
        public string autonick
        {
            get;
            set;
        }

        public string generisiNick()
        {
            p++;
            return "gostbroj" + p;
           
        }


    }
}
