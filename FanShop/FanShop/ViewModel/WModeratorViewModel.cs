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
        private int proizvodId;

        public WModeratorViewModel() 
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka();
            listaProizvoda = new ObservableCollection<Proizvod>(bp.VratiKatalog());

            Dodaj = new RelayCommand(dodaj);
            Obrisi = new RelayCommand(obrisi);
        }

        public ICommand Dodaj { get; set; }
        public ICommand Obrisi { get; set; }

        public ObservableCollection<Proizvod> Proizvodi
        {
            get { return listaProizvoda; }
            set { listaProizvoda = value; OnPropertyChanged("Proizvodi"); }
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
