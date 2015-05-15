using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FanShop
{
    public class Stavka
    {
        private Proizvod proizvod;
        private string velicina;
        private int kolicina;

        public Stavka()
        {
            this.Proizvod = new Proizvod();
            this.Velicina = "";
            this.Kolicina = 0;
        }

        public Stavka(Stavka s)
        {
            this.Proizvod = s.Proizvod;
            this.Velicina = s.Velicina;
            this.Kolicina = s.Kolicina;
        }

        public Proizvod Proizvod
        {
            get { return proizvod; }
            set { proizvod = value; OnPropertyChanged("Proizvod"); }
        }

        public string Velicina
        {
            get { return velicina; }
            set { velicina = value; OnPropertyChanged("Velicina"); }
        }

        public int Kolicina
        {
            get { return kolicina; }
            set { kolicina = value; OnPropertyChanged("Kolicina"); }
        }

        public override string ToString()
        {
            return Proizvod.ToString() + ", x" + Kolicina + " | " + (Proizvod.Cijena * Kolicina).ToString() + " KM";
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
