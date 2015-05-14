using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FanShop
{
    public class Proizvod : INotifyPropertyChanged, IDataErrorInfo
    {
        private int id;
        private decimal cijena;
        private string slika;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }
        public decimal Cijena
        {
            get { return cijena; }
            set { cijena = value; OnPropertyChanged("Cijena"); }
        }
        public string Slika
        {
            get { return slika; }
            set { slika = value; OnPropertyChanged("Slika"); }
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
            "Cijena", "Slika"
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
                case "Cijena":
                    error = validirajCijenu();
                    break;
               case "Slika":
                    error = validirajSliku();
                    break;
                
            }
            return error;
        }

        public string validirajCijenu()
        {
            if (String.IsNullOrEmpty(Cijena.ToString()))
            {
                return "Morate unijeti cijenu";
            }
            

            return null;
        }
        public string validirajSliku()
        {
            if (String.IsNullOrEmpty(Slika))
            {
                return "Morate učitati sliku klikom da dugme dodaj";
            }
            return null;
        }

       
    }
}
