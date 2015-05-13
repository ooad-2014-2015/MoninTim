using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FanShop
{
    public class Clan : INotifyPropertyChanged
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
    }
}
