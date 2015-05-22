using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.IO;

namespace FanShop.ViewModel
{
    class SignUpViewModel: INotifyPropertyChanged
    {
        private Clan clan;
        private string s, sourceurl;

        public SignUpViewModel()
        {
            clan = new Clan();

            Registracija = new RelayCommand(registracija);
            Nazad = new RelayCommand(nazad);
        }

        public Clan Clan
        {
            get { return clan; }
            set { clan = value; }
        }

        public string S
        {
            get { return s; }
            set { s = value; OnPropertyChanged("S"); }
        }

        public string SourceURL
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\poz.jpg";
               
            }
            set
            {
                sourceurl = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\poz.jpg";
                OnPropertyChanged("SourceURL");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand Registracija { get; set; }
        public ICommand Nazad { get; set; }

        private void registracija(object parametar)
        {
            if (clan.IsValid)
            {
                Baza.BazaPodataka bp = new Baza.BazaPodataka();
                Clan.Id = bp.UnesiClana(Clan.Username, Clan.Password, Clan.Email, Clan.Adresa, Clan.Broj_telefona);
                S="Uspješno ste se registrovali na FanShop FK Hepek.\nDobro došli.\nDa posjetite stranicu kliknite dugme ispod.";
            }
            else
            {
                System.Windows.MessageBox.Show("Pokušavate unijeti pogrešne podatke!");
            }
        }

        private void nazad(object parametar)
        {
            // hau ?!?!  MAYBE LIKE THIS??
            
            GlavnaForma g = new GlavnaForma();
            g.DataContext = new GlavnaFormaViewModel(g);
            g.Show();
            // :D
        }
    }
}
