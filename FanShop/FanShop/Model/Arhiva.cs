using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanShop
{
    public class Arhiva
    {
        public int ID
        { get; set; }

      

        public int Kolicina
        { get; set; }

        public string Tip
        {
            get;
            set;
        }

        public Arhiva(int id,  int kolicina, string tip)
        {
            ID = id;
         
            Kolicina = kolicina;
            Tip = tip;
        }

       

        public List<Proizvod> dajNajprodavanijeZaDan()
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka();
            return bp.VratiZaDanas();
        }

        public List<Proizvod> dajNajprodavanijeZaGodinu()
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka();
            return bp.VratiZaGodinu();
        }
        public List<Proizvod> dajNajprodavanijeZaMjesec()
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka();
            return bp.VratiZaMjesec();
        }

    }
}
