using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FanShop.ViewModel
{
    class PlaćanjeViewModel
    {
        private WFanShopViewModel katalogViewModel;
        private Plaćanje view;
        private bool kartica;
        private string racunTekst;
        private Transakcija transakcija;

        public PlaćanjeViewModel(WFanShopViewModel vm, Plaćanje view) 
        {
            katalogViewModel = vm;
            this.view = view;

            SetujTransakciju();
            RacunTekst = Transakcija.DajRacun();

            Naruci = new RelayCommand(naruci);
        }

        public bool Kartica
        {
            get { return kartica; }
            set { kartica = value; }
        }

        public string RacunTekst
        {
            get { return racunTekst; }
            set { racunTekst = value; }
        }

        public Transakcija Transakcija
        {
            get { return transakcija; }
            set { transakcija = value; }
        }

        public ICommand Naruci { get; set; }

        private void naruci(object parametar)
        {
            
        }

        private void SetujTransakciju()
        {
            transakcija = new Transakcija();
            transakcija.Korpa = katalogViewModel.Korpa;
        }
    }
}
