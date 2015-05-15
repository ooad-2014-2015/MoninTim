using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace FanShop
{
    public class Korpa
    {
        private ObservableCollection<Stavka> stavke;
        private string sifraRacuna;
        private decimal ukupnoCijena;

        public Korpa()
        {
            stavke = new ObservableCollection<Stavka>();
            sifraRacuna = "4";  // https://imgs.xkcd.com/comics/random_number.png
            ukupnoCijena = 0;
        }

        public ObservableCollection<Stavka> Stavke
        {
            get { return stavke; }
            set { stavke = value; OnPropertyChanged("Stavke"); }
        }

        public string SifraRacuna
        {
            get { return sifraRacuna; }
            set { sifraRacuna = value; OnPropertyChanged("SifraRacuna"); }
        }

        public decimal UkupnoCijena
        {
            get { ukupnoCijena = IzracunajUkupnuCijenu(); return ukupnoCijena; }
            set { ukupnoCijena = value; OnPropertyChanged("UkupnoCijena"); }
        }

        private decimal IzracunajUkupnuCijenu()
        {
            decimal uk = 0;
            foreach (Stavka s in stavke) { uk += s.Proizvod.Cijena * s.Kolicina; }
            return uk;
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
