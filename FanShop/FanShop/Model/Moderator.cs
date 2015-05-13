using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace FanShop
{
    public class Moderator : Osoba, INotifyPropertyChanged, IDataErrorInfo
    {
        private string username, password, ime_prezime;
        private int id;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        public string Ime_prezime
        {
            get { return ime_prezime; }
            set { ime_prezime = value; OnPropertyChanged("Ime_prezime"); }
        }

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        public override string ToString()
        {
            return "(" + this.Id + ") " + this.Ime_prezime + " - " + this.Username;
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
            "Username","Ime_prezime","Password"
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
                case "Ime_prezime":
                    error = validirajIme();
                    break;
                case "Password":
                    error = validirajPassword();
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
            return null;
        }

        private string validirajIme()
        {
            if (String.IsNullOrEmpty(Ime_prezime))
            {
                return "Ime mora biti uneseno";
            }
            if (Ime_prezime.ToUpper() == "ADMIN")
            {
                return "Ime ne može glasiti -Admin- ";
            }
            return null;
        }

        private string validirajPassword()
        {
            if (String.IsNullOrEmpty(Password))
            {
                return "Morate navesti password";
            }
            if (Password.Length<=4)
            {
                return "Password mora imati više od 4 znaka!";
            }
            return null;
        }


    }
}
