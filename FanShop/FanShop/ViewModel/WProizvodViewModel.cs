using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using System.IO;
using System.ComponentModel;

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
            {
                Proizvod.Slika = o.FileName;
            }
           
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

                    int id = bp.UnesiUKatalog(c);
                    Proizvod.Slika = Proizvod.Slika.Replace("\\", "\\\\"); // da se u bazi escape-a '\' char

                    switch (c)
                    {
                        case "d":
                            bp.UnesiDres(id.ToString(), pro.Slika, (pro.Cijena).ToString());
                            Dres d = new Dres(Proizvod);
                            d.Id = id;
                            this.Parent.Proizvodi.Add(d);
                            //d.Velicine = ??
                            break;
                        case "s":
                            bp.UnesiSal(id.ToString(), pro.Slika, (pro.Cijena).ToString());
                            Sal s = new Sal(Proizvod);
                            s.Id = id;
                            this.Parent.Proizvodi.Add(s);
                            break;
                        case "k":
                            bp.UnesiKapu(id.ToString(), pro.Slika, (pro.Cijena).ToString());
                            Kapa k = new Kapa(Proizvod);
                            k.Id = id;
                            // k.Velicine = ??
                            this.Parent.Proizvodi.Add(k);
                            break;
                        case "p":
                            bp.UnesiPrivjesak(id.ToString(), pro.Slika, (pro.Cijena).ToString());
                            Privjesak p = new Privjesak(Proizvod);
                            p.Id = id;
                            this.Parent.Proizvodi.Add(p);
                            break;
                    }
                    
                    //Moderator.Id = bp.UnesiUposlenika(mod.Username, mod.Password, mod.Ime_prezime);
                    
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Pokušavate unijeti pogrešne parametre!");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


}
