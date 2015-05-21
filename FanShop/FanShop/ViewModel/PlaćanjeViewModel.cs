using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace FanShop.ViewModel
{
    class PlaćanjeViewModel
    {
        private WFanShopViewModel katalogViewModel;
        private Plaćanje view;
        private bool karticaCb;
        private string racunTekst;
        private Transakcija transakcija;
        private Kartica kartica;
        private bool naruceno = false;

        public PlaćanjeViewModel(WFanShopViewModel vm, Plaćanje view) 
        {
            katalogViewModel = vm;
            this.view = view;
            kartica = new Kartica();

            SetujTransakciju();
            RacunTekst = Transakcija.DajRacun();

            Naruci = new RelayCommand(naruci);
        }

        public bool KarticaCb
        {
            get { return karticaCb; }
            set { karticaCb = value; }
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

        public Kartica Kartica
        {
            get { return kartica; }
            set { kartica = value; OnPropertyChanged("Kartica");  }
        }

        public ICommand Naruci { get; set; }

        private void naruci(object parametar)
        {
            if (naruceno) 
            {
                System.Windows.Forms.MessageBox.Show("Već ste jednom kupili ove proizvode. Ako želite još jednom da ponovite transakciju, pritisnite opet \"Naruči\"", "Upozorenje!");
                naruceno = false;
                return;
            }

            if (KarticaCb == true && this.Kartica.IsValid == false)
            {
                System.Windows.Forms.MessageBox.Show("Podaci o kartici koje ste unijeli nisu uredu! Provjerite ih opet.", "Greška!");
                return;
            }

            Baza.BazaPodataka bp = new Baza.BazaPodataka();

            foreach (Stavka s in Transakcija.Korpa.Stavke)
            {
                bp.UnesiUArhivu(s.Proizvod.Id.ToString(), s.Kolicina.ToString(), "DATE(CURDATE())");
            }

            System.Windows.Forms.MessageBox.Show("Uspješno kupljeno! Zahvaljujemo se!", "Čestitamo");
            naruceno = true;
        }

        private void SetujTransakciju()
        {
            transakcija = new Transakcija();
            transakcija.Korpa = katalogViewModel.Korpa;
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
