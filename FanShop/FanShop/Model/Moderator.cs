using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.ComponentModel;

namespace FanShop
{
    public class Moderator : Osoba, INotifyPropertyChanged
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
    }
}
