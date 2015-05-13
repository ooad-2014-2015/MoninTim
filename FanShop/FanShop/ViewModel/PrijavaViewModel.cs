using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FanShop.ViewModel
{
    public class PrijavaViewModel
    {
        private string username;
        private string password;
        private object bindedView; 

        public PrijavaViewModel(object view)
        {
            Login = new RelayCommand(login);
            username = password = "";
            bindedView = view;
        }
        
        public string Username 
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public ICommand Login { get; set; }

        public Action CloseAction { get; set; }
        
        private void login(object parametar)
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka();
            if (bp.ProvjeriLoginPodatke(Username, Password, true))
            {
                if (Username == "admin" && bindedView is Login1)
                {
                    Admin a = new Admin();
                    a.DataContext = new AdminViewModel();
                    a.Show();
                    (bindedView as Login1).Hide();
                }
                else if (Username != "admin" && bindedView is Login2)
                {
                    WModerator w = new WModerator();
                    w.DataContext = new WModeratorViewModel();
                    w.Show();
                    (bindedView as Login2).Hide();
                }
                else
                {
                    // TODO: obavijestiti da je fulao formu (??? ili se podrazumijeva ???)
                }
            }
            else
            {
                // TODO: obavijestiti da ne valja password 
            }
            //CloseAction();
        }
    }
}
