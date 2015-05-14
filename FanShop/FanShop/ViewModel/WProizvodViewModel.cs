using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;

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
            Sl = new RelayCommand(slika);
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
        public ICommand Sl { get; set; }
        public Action CloseAction { get; set; }

        private void slika(object parametar)
        {
            OpenFileDialog o = new OpenFileDialog();
            if (o.ShowDialog() == true)
                parent.w.sl.DataContext = File.ReadAllText(o.FileName);
           
        }

        private void dodaj(object parametar)
        {
            if (pro.IsValid)
            {
                if (parent.w.rbDres.IsChecked == false && parent.w.rbSal.IsChecked == false && parent.w.rbPrivjesak.IsChecked == false && parent.w.rbKapa.IsChecked == false)
                {
                    System.Windows.MessageBox.Show("Selektirajte koji tip proizvoda unesete klikom na jednu od opcija.");
                }
                else
                {
                    Baza.BazaPodataka bp = new Baza.BazaPodataka();
                    string c = " ";
                    if (parent.w.rbDres.IsChecked == true)
                    {
                        c = "d";
                    }
                    else if (parent.w.rbSal.IsChecked == true)
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
            else
            {
                System.Windows.MessageBox.Show("Pokušavate unijeti pogrešne parametre!");
            }
        }
        
    }


}
