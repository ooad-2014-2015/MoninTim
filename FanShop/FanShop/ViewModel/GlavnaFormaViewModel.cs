using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace FanShop.ViewModel
{
    class GlavnaFormaViewModel: INotifyPropertyChanged
    {
        private Clan clan;
        private GlavnaForma glavnaView; // view

        public GlavnaFormaViewModel(GlavnaForma gf)
        {
            clan = new Clan();
            glavnaView = gf;

            UserLogin = new RelayCommand(userLogin);
            Login = new RelayCommand(login);
            AdminLogin = new RelayCommand(adminLogin);
            ModeratorLogin = new RelayCommand(moderatorLogin);
            Registracija = new RelayCommand(registracija);
            Gost = new RelayCommand(gost);
            ImageUrl = Environment.CurrentDirectory + AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\slika.jpg";
            icon = Environment.CurrentDirectory + AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\icon.png";
        }

        public GlavnaForma GlavaView
        {
            get;
            set;
        }
        public string icon{
        get { return AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\icon.png"; }
        set
        {
            s = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "")  + @"\icon.png";
            OnPropertyChanged("ImageUrl");
        }
}

        public Clan Clan
        {
            get { return clan; }
            set { clan = value; }
        }

        string s;
        string str;

        public string Str
        {
            get { return str; }
            set { str = value; OnPropertyChanged("Str"); }
        }

        public string ImageUrl
        {
            get { return AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\slika.jpg"; }
            set
            {
                s = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "")  + @"\slika.jpg";
                OnPropertyChanged("ImageUrl");
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
        public ICommand UserLogin { get; set; }
        public ICommand Login { get; set; }
       
        public ICommand AdminLogin { get; set; }
        public ICommand ModeratorLogin { get; set; }
        public ICommand Registracija { get; set; }
        public ICommand Gost { get; set; }

        private void userLogin(object parametar)
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka();
            if (bp.ProvjeriLoginPodatke(Clan.Username, Clan.Password, false))
            {
                WFanShop fs = new WFanShop();
                Clan = bp.VratiClana(Clan.Username, Clan.Password);
                fs.DataContext = new WFanShopViewModel(fs, Clan);
                fs.Show();
                fs.lab.Content = fs.lab.Content + " " + Clan.Username;
                glavnaView.Hide();
            }
            else
            {
                Str = "Username ili password nisu tačni.";
            }
        }

        public void login(object param)
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka();
            if (bp.ProvjeriLoginPodatke(Clan.Username, Clan.Password, false))
            {
                WFanShop fs = new WFanShop();
                Clan = bp.VratiClana(Clan.Username, Clan.Password);
                fs.DataContext = new WFanShopViewModel(fs, Clan);
                fs.Show();
                fs.lab.Content = fs.lab.Content + " " + Clan.Username;
                glavnaView.Hide();
            }
            else
            {
                Str = "Username ili password nisu tačni.";
            }
        }

        private void adminLogin(object parametar)
        {
            Login1 l = new Login1();
            l.DataContext = new PrijavaViewModel(l);
            l.Show();
            glavnaView.Hide();
        }

        private void moderatorLogin(object parametar)
        {
            Login2 l = new Login2();
            l.DataContext = new PrijavaViewModel(l);
            l.Show();
            glavnaView.Hide();
        }

        private void registracija(object parametar)
        {
            SignUp s = new SignUp();
            s.DataContext = new SignUpViewModel();
            glavnaView.Hide();
            s.Show();
        }

        private void gost(object parametar)
        {

            WFanShop fs = new WFanShop();
            fs.DataContext = new WFanShopViewModel(fs, Clan);
            Gost g = new Gost();
            string s = g.generisiNick();
            fs.lab.Content = fs.lab.Content + "   " + s;
            fs.Show();
            glavnaView.Hide();
          
            
        }
    }
}
