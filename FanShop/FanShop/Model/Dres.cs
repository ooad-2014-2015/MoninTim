using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FanShop
{
    public class Dres : Proizvod, INotifyPropertyChanged, IDataErrorInfo
    {
        private string velicine;

        public Dres()
        {
            velicine = "";
        }

        public Dres(Proizvod p)
        {
            this.Id = p.Id;
            this.Cijena = p.Cijena;
            this.Slika = p.Slika;
            velicine = "";
        }

        public string Velicine
        {
            get { return velicine; }
            set { velicine = value; OnPropertyChanged("Velicine"); }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        

        public bool IsValid
        {
            get
            {
                foreach (string property in validateProperties)
                {
                    if (getValidationError(property) != null)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        static readonly string[] validateProperties =
        {
            "Velicina"
        };

        string IDataErrorInfo.Error
        {
            get { return null; }
        }
        //Ponasa se tako da ako se vrati null nema errora ako se vrati neka vrijednost validacija nije uspjela
        string IDataErrorInfo.this[string propertyName]
        {
            get { return getValidationError(propertyName); }
        }
        //Ovisno o tome koji property se mjenja
        string getValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Velicina":
                    error = validirajVelicinu();
                    break;
                
            }
            return error;
        }

        public string validirajVelicinu()
        {
            if (String.IsNullOrEmpty(Velicine))
            {
                return "Morate unijeti cijenu";
            }
            if (Velicine != "L" && velicine != "S" && velicine != "M" && velicine != "XL")
            {
                return "Unesite pravilan parametar";
            }

            return null;
        }
            
        public override string ToString()
        {
            return Id + " Dres        " + Cijena + " KM";
        }
            
    }
}
