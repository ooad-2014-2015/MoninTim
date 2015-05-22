using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FanShop.ViewModel
{
    class WModeratorViewModel
    {
        private ObservableCollection<Proizvod> listaProizvoda;
        private ObservableCollection<Proizvod> statistikaDan;
        private ObservableCollection<Proizvod> statistikaMjesec;
        private ObservableCollection<Proizvod> statistikaGodina;

        private int proizvodId;
        public int idModeratora;

        public WModeratorViewModel(string username) 
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka();
            listaProizvoda = new ObservableCollection<Proizvod>(bp.VratiKatalog());
            statistikaDan = new ObservableCollection<Proizvod>(bp.VratiZaDanas());
            statistikaMjesec = new ObservableCollection<Proizvod>(bp.VratiZaMjesec());
            statistikaGodina = new ObservableCollection<Proizvod>(bp.VratiZaGodinu());
            ImageUrl = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\slika.jpg";

            Dodaj = new RelayCommand(dodaj);
            Obrisi = new RelayCommand(obrisi);

            idModeratora = bp.VratiIDModeratora(username);
        }

        public ICommand Dodaj { get; set; }
        public ICommand Obrisi { get; set; }

        string s;

        public string ImageUr
        {
            get { return AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\slik.jpg"; }
            set
            {
                s = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\slik.jpg";
                OnPropertyChanged("ImageUrl");
            }

        }

        public string ImageUrl
        {
            get { return AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\slika.jpg"; }
            set
            {
                s = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\slika.jpg";
                OnPropertyChanged("ImageUrl");
            }

        }

        public ObservableCollection<Proizvod> Proizvodi
        {
            get { return listaProizvoda; }
            set { listaProizvoda = value; OnPropertyChanged("Proizvodi"); }
        }

        public ObservableCollection<Proizvod> StatistikaDan
        {
            get { return statistikaDan; }
            set { statistikaDan = value; OnPropertyChanged("StatistikaDan"); }
        }
        public ObservableCollection<Proizvod> StatistikaMjesec
        {
            get { return statistikaMjesec; }
            set { statistikaMjesec = value; OnPropertyChanged("StatistikaMjesec"); }
        }
        public ObservableCollection<Proizvod> StatistikaGodina
        {
            get { return statistikaGodina; }
            set { statistikaGodina = value; OnPropertyChanged("StatistikaGodina"); }
        }


        public int ProizvodID
        {
            get { return proizvodId; }
            set { proizvodId = value; OnPropertyChanged("ProizvodID"); }
        }
        public WProizvod w;
        private void dodaj(object parametar)
        {
            w = new WProizvod();
            w.DataContext = new WProizvodViewModel(this);
            w.Show();
        }

        private void obrisi(object parametar)
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka();
            bp.ObrisiProizvod(ProizvodID.ToString());
            bp.UnesiULog(idModeratora.ToString(), "Obrisao/la artikal sa ID-om " + ProizvodID.ToString(), "DATE(CURDATE())"); 
            this.Proizvodi.Remove(x => x.Id == ProizvodID);
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
