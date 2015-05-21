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
        private bool rbSal, rbDres, rbPrivjesak, rbKapa;

        public WProizvodViewModel(WModeratorViewModel p)
        {
            this.parent = p;
            Dodaj = new RelayCommand(dodaj);
            Sl = new RelayCommand(slika);
            pro = new Proizvod();
        }

        public bool RbSal
        {
            get { return rbSal; }
            set { rbSal = value; }
        }

        public bool RbDres
        {
            get { return rbDres; }
            set { rbDres = value; }
        }

        public bool RbKapa
        {
            get { return rbKapa; }
            set { rbKapa = value; }
        }

        public bool RbPrivjesak
        {
            get { return rbPrivjesak; }
            set { rbPrivjesak = value; }
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
                if (RbDres == false && RbSal== false && rbPrivjesak == false && rbKapa == false)
                {
                    System.Windows.MessageBox.Show("Selektirajte koji tip proizvoda unesete klikom na jednu od opcija.");
                }
                else
                {
                    Baza.BazaPodataka bp = new Baza.BazaPodataka();
                    string c = " ";
                    if (RbDres== true)
                    {
                        c = "d";
                    }
                    else if (RbSal == true)
                    {
                        c = "s";
                    }
                    else if (RbPrivjesak == true)
                    {
                        c = "p";
                    }
                    else if (RbKapa== true)
                    {
                        c = "k";
                    }

                    int id = bp.UnesiUKatalog(c);
                    Proizvod.Slika = Proizvod.Slika.Replace("\\", "\\\\"); // da se u bazi escape-a '\' char

                    switch (c)
                    {
                        case "d":
                            bp.UnesiDres(id.ToString(), pro.Slika, (pro.Cijena).ToString());
                            bp.UnesiULog(Parent.idModeratora.ToString(), "Unio/la dres sa ID-om " + id.ToString(), "DATE(CURDATE())");

                            Dres d = new Dres(Proizvod);
                            d.Id = id;
                            this.Parent.Proizvodi.Add(d);
                            pro.Slika = ""; pro.Cijena = 0; RbDres=false;
                            //d.Velicine = ??
                            break;
                        case "s":
                            bp.UnesiSal(id.ToString(), pro.Slika, (pro.Cijena).ToString());
                            bp.UnesiULog(Parent.idModeratora.ToString(), "Unio/la sal sa ID-om " + id.ToString(), "DATE(CURDATE())");

                            Sal s = new Sal(Proizvod);
                            s.Id = id;
                            this.Parent.Proizvodi.Add(s);
                               pro.Slika = ""; pro.Cijena = 0; RbSal=false;
                         
                            break;
                        case "k":
                            bp.UnesiKapu(id.ToString(), pro.Slika, (pro.Cijena).ToString());
                            bp.UnesiULog(Parent.idModeratora.ToString(), "Unio/la kapu sa ID-om " + id.ToString(), "DATE(CURDATE())");

                            Kapa k = new Kapa(Proizvod);
                            k.Id = id;
                            // k.Velicine = ??
                            this.Parent.Proizvodi.Add(k);
                               pro.Slika = ""; pro.Cijena = 0; RbKapa=false;
                         
                            break;
                        case "p":
                            bp.UnesiPrivjesak(id.ToString(), pro.Slika, (pro.Cijena).ToString());
                            bp.UnesiULog(Parent.idModeratora.ToString(), "Unio/la privjesak sa ID-om " + id.ToString(), "DATE(CURDATE())");

                            Privjesak p = new Privjesak(Proizvod);
                            p.Id = id;
                            this.Parent.Proizvodi.Add(p);
                               pro.Slika = ""; pro.Cijena = 0; RbPrivjesak=false;
                         
                            break;
                    }
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
