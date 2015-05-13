using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace FanShop
{
    public class Clan : INotifyPropertyChanged, IDataErrorInfo
    {
        private int id;
        private string username, password, email, adresa, broj_telefona;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public string Username 
        {
            get { return username;}
            set { username = value; OnPropertyChanged("Username"); }
        }

        public string Password 
        {
            get { return password;}
            set { password = value; OnPropertyChanged("Password"); }
        }

        public string Email 
        {
            get { return email;}
            set { email = value; OnPropertyChanged("Email"); }
        }

        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; OnPropertyChanged("Adresa"); }
        }

        public string Broj_telefona
        {
            get { return broj_telefona; }
            set { broj_telefona = value; OnPropertyChanged("Broj_telefona"); }
        }

        public override string ToString()
        {
            return "(" + this.Id + ") " + this.Username;
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
            "Username","Password", "Email", "Broj_telefona","Adresa"
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
                case "Username":
                    error = validirajUsername();
                    break;
             
                case "Password":
                    error = validirajPassword();
                    break;
                case "Email":
                    error = validirajEmail();
                    break;
                case "Broj_telefona":
                    error = validirajBroj();
                    break;
                case "Adresa":
                    error = validirajAdresa();
                    break;
            }
            return error;
        }

        private string validirajUsername()
        {
            if (String.IsNullOrEmpty(Username))
            {
                return "Username mora biti unesen";
            }
            if (Username.ToUpper() == "ADMIN")
            {
                return "Username ne može glasiti -Admin- ";
            }
            if (Username.ToUpper() == "DROP TABLE")
            {
                return "Username ne može glasiti -DROP TABLE-";
            }
            return null;
        }

   

        private string validirajPassword()
        {
            if (String.IsNullOrEmpty(Password))
            {
                return "Morate navesti password";
            }
            if (Password.Length <= 4)
            {
                return "Password mora imati više od 4 znaka!";
            }
            if (Password.ToUpper() == "DROP TABLE")
            {
                return "Username ne može glasiti -DROP TABLE-";
            }
            return null;
        }

        private string validirajEmail()
        {
            if (String.IsNullOrEmpty(Email))
            {
                return "Morate navesti email";
            }
            else
            {
               
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(Email);
                if (!match.Success)

                    return "Neispravna email adresa";
            }
            return null;
        }

        private string validirajBroj()
        {
            if (String.IsNullOrEmpty(Broj_telefona))
            {
                return "Morate navesti broj";
            }

            return null;
        }

        private string validirajAdresa()
        {
            if (String.IsNullOrEmpty(Adresa))
            {
                return "Morate navesti adresu";
            }
            if (Adresa.ToUpper() == "DROP TABLE")
            {
                return "Adresa ne može glasiti -drop table-";
            }
            return null;
        }

    }
}
