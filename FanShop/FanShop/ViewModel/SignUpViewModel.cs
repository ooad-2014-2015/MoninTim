using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FanShop.ViewModel
{
    class SignUpViewModel
    {
        private Clan clan;

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

        public ICommand Registracija { get; set; }
        public ICommand Nazad { get; set; }

        private void registracija(object parametar)
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka();
            Clan.Id = bp.UnesiClana(Clan.Username, Clan.Password, Clan.Email, Clan.Adresa, Clan.Broj_telefona);
            // i sta sad ?? gdje će? xD
        }

        private void nazad(object parametar)
        {
            // hau ?!?! 
        }
    }
}
