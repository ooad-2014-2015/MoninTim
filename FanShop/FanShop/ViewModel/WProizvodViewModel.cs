using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FanShop.ViewModel
{
    class WProizvodViewModel
    {
        private Proizvod pro;
        private WModeratorViewModel parent;

        public WProizvodViewModel(WModeratorViewModel p)
        {
            this.parent = p;
            Dodaj = new RelayCommand(dodaj);
            pro = new Proizvod();
        }

        public WModeratorViewModel Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public Proizvod Proizvod
        {
            get { return pro; }
            set { pro = value;}
        }

        public ICommand Dodaj { get; set; }
        public Action CloseAction { get; set; }

        private void dodaj(object parametar)
        {
            // TODO: validacija
            Baza.BazaPodataka bp = new Baza.BazaPodataka();
            string c=" ";
            if (parent.w.rbDres.IsChecked == true)
            {
                c = "d";
            }
            else if(parent.w.rbSal.IsChecked == true)
            {
                c = "s";
            }
            else if (parent.w.rbPrivjesak.IsChecked == true)
            {
                c = "p";
            }
            else if (parent.w.rbKapa.IsChecked == true)
            {
                c = "k";
            }

            switch (c)
            {
                case "d":
                    bp.UnesiDres(pro.Slika, (pro.Cijena).ToString());
                    break;
                case "s":
                    bp.UnesiSal(pro.Slika, (pro.Cijena).ToString());
                    break;
                case "k":
                    bp.UnesiKapu(pro.Slika, (pro.Cijena).ToString());
                    break;
                case "p":
                    bp.UnesiPrivjesak(pro.Slika, (pro.Cijena).ToString());
                    break;
            }
            bp.UnesiUKatalog(c);
            //Moderator.Id = bp.UnesiUposlenika(mod.Username, mod.Password, mod.Ime_prezime);
            this.Parent.Proizvodi.Add(this.Proizvod);
        }
        
    }


}
