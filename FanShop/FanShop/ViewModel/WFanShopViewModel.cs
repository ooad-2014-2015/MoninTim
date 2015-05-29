using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FanShop.ViewModel
{
    class WFanShopViewModel
    {
        private ObservableCollection<Privjesak> collPrivjesak; 
        private ObservableCollection<Dres>      collDres;
        private ObservableCollection<Sal>       collSal;
        private ObservableCollection<Kapa>      collKapa;

        string dres;
        public string DresUrl
        {
            get { return dres; }
            set { 
                    dres = value;
                    OnPropertyChanged("DresUrl");
                }
        }


        private Privjesak selectedPrivjesak;
        private Dres      selectedDres;
        private Sal       selectedSal;
        private Kapa      selectedKapa;

        private Stavka stavkaDres;
        private Stavka stavkaPrivjesak;
        private Stavka stavkaKapa;
        private Stavka stavkaSal;

        private Korpa korpa;
        private Stavka stavkaKorpa;

        private WFanShop View;
        private Clan CLAN;

        public WFanShopViewModel(WFanShop view, Clan c)
        {
            View = view;
            
            UcitajProizvodeUKolekcije();
            selectedDres = collDres[0];
            selectedKapa = collKapa[0];
            selectedPrivjesak = collPrivjesak[0];
            selectedSal = collSal[0];
            ProfilUrl = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\profil.png";
            Url = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\social.jpg";

            korpa = new Korpa();
            stavkaKorpa = new Stavka();
            Clan = c;

            stavkaDres = new Stavka();
            stavkaPrivjesak = new Stavka();
            stavkaKapa = new Stavka();
            stavkaSal = new Stavka();

            KupiPrivjesak = new RelayCommand(kupiPrivjesak); 
            KupiDres = new RelayCommand(kupiDres);
            KupiKapu = new RelayCommand(kupiKapu);
            KupiSal = new RelayCommand(kupiSal);

            PrevPrivjesak = new RelayCommand(prevPrivjesak); 
            PrevDres = new RelayCommand(prevDres);
            PrevKapa = new RelayCommand(prevKapa);
            PrevSal = new RelayCommand(prevSal);

            NextPrivjesak = new RelayCommand(nextPrivjesak);
            NextDres = new RelayCommand(nextDres);
            NextKapa = new RelayCommand(nextKapa);
            NextSal = new RelayCommand(nextSal);

            Izbaci = new RelayCommand(izbaci);
            Plati = new RelayCommand(plati);

            Promijeni = new RelayCommand(promijeni);
            Deaktiviraj = new RelayCommand(deaktiviraj);
            Pomoc = new RelayCommand(pomoc);
           

        }

        private void UcitajProizvodeUKolekcije()
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka();

            collPrivjesak = new ObservableCollection<Privjesak>(bp.VratiPrivjeske());
            collDres = new ObservableCollection<Dres>(bp.VratiDresove());
            collSal = new ObservableCollection<Sal>(bp.VratiSalove());
            collKapa = new ObservableCollection<Kapa>(bp.VratiKape());
        }

        #region Properties
        public ObservableCollection<Privjesak> Privjesci {
            get { return collPrivjesak; }
            set { collPrivjesak = value; OnPropertyChanged("Privjesci"); }
        }

        public ObservableCollection<Dres> Dresovi
        {
            get { return collDres; }
            set { collDres = value; OnPropertyChanged("Dresovi"); }
        }

        public ObservableCollection<Sal> Salovi
        {
            get { return collSal; }
            set { collSal = value; OnPropertyChanged("Salovi"); }
        }

        public ObservableCollection<Kapa> Kape
        {
            get { return collKapa; }
            set { collKapa = value; OnPropertyChanged("Kape"); }
        }

        public Clan Clan
        {
            get { return CLAN; }
            set { CLAN = value;
                  OnPropertyChanged("Clan");
                }
        }

     

        public Dres Dres { // trenutno selektirani
            get { return selectedDres; }
            set { selectedDres = value;
                  OnPropertyChanged("CurrDres");
                }
            }
        

        public Sal Sal
        {
            get { return selectedSal; }
            set { 
                  selectedSal = value;
                  OnPropertyChanged("CurrSal"); }
                }

        public Kapa Kapa
        {
            get { return selectedKapa; }
            set
            {
                  selectedKapa = value;
                  OnPropertyChanged("CurrKapa"); }
        }

        public Privjesak Privjesak
        {
            get { return selectedPrivjesak; }
            set
            {
               
                selectedPrivjesak = value;
                OnPropertyChanged("CurrPrivjesak"); }
            }

        public Stavka StavkaDres
        {
            get { return stavkaDres; }
            set { stavkaDres = value; OnPropertyChanged("StavkaDres"); }
        }

        public Stavka StavkaPrivjesak
        {
            get { return stavkaPrivjesak; }
            set { stavkaPrivjesak = value; OnPropertyChanged("StavkaPrivjesak"); }
        }

        public Stavka StavkaKapa
        {
            get { return stavkaKapa; }
            set { stavkaKapa = value; OnPropertyChanged("StavkaKapa"); }
        }

        public Stavka StavkaSal
        {
            get { return stavkaSal; }
            set { stavkaSal = value; OnPropertyChanged("StavkaSal"); }
        }

        public Korpa Korpa
        {
            get { return korpa; }
            set { korpa = value; OnPropertyChanged("Korpa"); }
        }

        public Stavka StavkaKorpa
        {
            get { return stavkaKorpa; }
            set { stavkaKorpa = value; OnPropertyChanged("StavkaKorpa"); }
        }
        string s,p;
        
        public string ProfilUrl
        {
            get { return AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\profil.png"; }
            set
            {
                s = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\profil.png";
                OnPropertyChanged("ProfilUrl");
            }
        }
        public string Url
        {
            get { return AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\social.jpg"; }
            set
            {
                p = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug", "") + @"\social.jpg";
                OnPropertyChanged("Url");
            }

        }


        public ICommand KupiPrivjesak { get; set; }
        public ICommand KupiDres { get; set; }
        public ICommand KupiKapu { get; set; }
        public ICommand KupiSal { get; set; }

        public ICommand PrevPrivjesak { get; set; }
        public ICommand PrevDres { get; set; }
        public ICommand PrevKapa { get; set; }
        public ICommand PrevSal { get; set; }

        public ICommand NextPrivjesak { get; set; }
        public ICommand NextDres { get; set; }
        public ICommand NextKapa { get; set; }
        public ICommand NextSal { get; set; }

        public ICommand Izbaci { get; set; }
        public ICommand Plati { get; set; }
        public ICommand Promijeni { get; set; }
        public ICommand Deaktiviraj { get; set; }

        public ICommand Pomoc { get; set; }
        public ICommand Help { get; set; }

        string novipass;
        public string NoviPassword
        {
            get { return novipass; }
            set { novipass = value; OnPropertyChanged("NoviPassword"); }

        }
        string mes;
        public string Mes
        {
            get { return mes; }
            set { mes = value; OnPropertyChanged("Mes"); }

        }

        #endregion

        private void promijeni(object parametar)
        {
            if (String.IsNullOrEmpty(NoviPassword)) System.Windows.MessageBox.Show("Novi password ne može biti prazan!");
            else
            {
                Baza.BazaPodataka bp = new Baza.BazaPodataka();
                bp.ObrisiClana(Clan.Id.ToString());
                bp.UnesiClana(Clan.Username, NoviPassword, Clan.Email, Clan.Adresa, Clan.Broj_telefona);
            }
        }
        private void deaktiviraj(object parametar)
        {
            if (System.Windows.MessageBox.Show("Jeste li sigurni da želite deaktivirati račun?", " ", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Warning) == System.Windows.MessageBoxResult.Yes)
            {
                Baza.BazaPodataka bp = new Baza.BazaPodataka();
                bp.ObrisiClana(Clan.Id.ToString());
           
                if (System.Windows.MessageBox.Show("Hvala na korištenju", "Ubuduće nećete moći koristiti ovaj račun", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning) == System.Windows.MessageBoxResult.OK)
                {
                    View.Close();   
                }
            }  
        }

        private void kupiPrivjesak(object parametar)
        {
            StavkaPrivjesak.Proizvod = Privjesak;

            if (ValidirajStavku(StavkaPrivjesak, false) == false) System.Windows.Forms.MessageBox.Show("Prosljeđene informacije o proizvodu koji želite kupiti nisu uredu!", "Greška!");

            else if (Korpa.Stavke.Any(x => x.Proizvod == StavkaPrivjesak.Proizvod))
            {
                Stavka s = new Stavka(Korpa.Stavke.First(x => x.Proizvod == StavkaPrivjesak.Proizvod));
                s.Kolicina += StavkaPrivjesak.Kolicina;
                IzmjeniStavkuUListi(s);
            }
            else
                Korpa.Stavke.Add(new Stavka(StavkaPrivjesak));
        }

        private void kupiDres(object parametar)
        {
            StavkaDres.Proizvod = Dres;

            if (ValidirajStavku(StavkaDres, true) == false) System.Windows.Forms.MessageBox.Show("Prosljeđene informacije o proizvodu koji želite kupiti nisu uredu!", "Greška!");

            else if (Korpa.Stavke.Any(x => x.Proizvod == StavkaDres.Proizvod))
            {
                Stavka s = new Stavka(Korpa.Stavke.First(x => x.Proizvod == StavkaDres.Proizvod));
                s.Kolicina += StavkaDres.Kolicina;
                IzmjeniStavkuUListi(s);
            }
            else
                Korpa.Stavke.Add(new Stavka(StavkaDres));
        }
        
        private void kupiSal(object parametar)
        {
            StavkaSal.Proizvod = Sal;

            if (ValidirajStavku(StavkaSal, false) == false) System.Windows.Forms.MessageBox.Show("Prosljeđene informacije o proizvodu koji želite kupiti nisu uredu!", "Greška!");

            else if (Korpa.Stavke.Any(x => x.Proizvod == StavkaSal.Proizvod))
            {
                Stavka s = new Stavka(Korpa.Stavke.First(x => x.Proizvod == StavkaSal.Proizvod));
                s.Kolicina += StavkaSal.Kolicina;
                IzmjeniStavkuUListi(s);
            }
            else
                Korpa.Stavke.Add(new Stavka(StavkaSal));
        }

        private void kupiKapu(object parametar)
        {
            StavkaKapa.Proizvod = Kapa;

            if (ValidirajStavku(StavkaKapa, true) == false) System.Windows.Forms.MessageBox.Show("Prosljeđene informacije o proizvodu koji želite kupiti nisu uredu!", "Greška!");
            
            else if (Korpa.Stavke.Any(x => x.Proizvod == StavkaKapa.Proizvod))
            {
                Stavka s = new Stavka(Korpa.Stavke.First(x => x.Proizvod == StavkaKapa.Proizvod));
                s.Kolicina += StavkaKapa.Kolicina;
                IzmjeniStavkuUListi(s);
            }
            else
                Korpa.Stavke.Add(new Stavka(StavkaKapa));
        }

        private void IzmjeniStavkuUListi(Stavka s)
        {
            /* razlog za ovo je što se OnPropertyChanged neće raisati ako samo uradim Količina++
             * u ObservableCollection. Tj raisa se samo na dodavanje i brisanje pa moram
             * bruteforceom da na ovaj objekat "nalijepim" novi. 
             * I da, moram for petljom jer ObservableCollection nema metode Find(predikat) >.<
             */ 

            for (int i = 0; i < Korpa.Stavke.Count; i++)
            {
                if (Korpa.Stavke[i].Proizvod.Id == s.Proizvod.Id)
                {
                    Korpa.Stavke[i] = new Stavka(s);
                    return;
                }
            }
        }

        private void pomoc(object param)
        {
            string s = Environment.CurrentDirectory;
            s = s.Replace("\\bin\\Debug", "");
            s += @"\HelpUser.xps";
            View.HelpUser hu = new View.HelpUser();
            hu.DataContext = new HelpViewModel(hu,s);
            hu.Show();
        }

    

        private void prevDres(object parametar)
        {
            if (collDres[0] == Dres) return;

            for (int i = 0; i < collDres.Count - 1; i++)
                if (collDres[i + 1] == Dres)
                {
                    Dres = collDres[i];
                    View.PromijeniSelektiraniDres(i);
                    return;
                }
        }

        private void prevKapa(object parametar)
        {
            if (collKapa[0] == Kapa) return;

            for (int i = 0; i < collKapa.Count - 1; i++)
                if (collKapa[i + 1] == Kapa)
                {
                    Kapa = collKapa[i];
                    View.PromijeniSelektiranuKapu(i);
                    return;
                }
        }

        private void prevSal(object parametar)
        {
            if (collSal[0] == Sal) return;

            for (int i = 0; i < collSal.Count - 1; i++)
                if (collSal[i + 1] == Sal)
                {
                    Sal = collSal[i];
                    View.PromijeniSelektiraniSal(i);
                    return;
                }
        }

        private void prevPrivjesak(object parametar)
        {
            if (collPrivjesak[0] == Privjesak) return;

            for (int i = 0; i < collPrivjesak.Count - 1; i++)
                if (collPrivjesak[i + 1] == Privjesak)
                {
                    Privjesak = collPrivjesak[i];
                    View.PromijeniSelektiraniPrivjesak(i);
                    return;
                }
        }

        private void nextDres(object parametar)
        {
            if (collDres[collDres.Count - 1] == Dres) return;

            for (int i = 0; i < collDres.Count - 1; i++)
                if (collDres[i] == Dres)
                {
                    Dres = collDres[i + 1];
                    View.PromijeniSelektiraniDres(i + 1);
                    return;
                }
        }

        private void nextKapa(object parametar)
        {
            if (collKapa[collKapa.Count - 1] == Kapa) return;

            for (int i = 0; i < collKapa.Count - 1; i++)
                if (collKapa[i] == Kapa)
                {
                    Kapa = collKapa[i + 1];
                    View.PromijeniSelektiranuKapu(i + 1);
                    return;
                }
        }

        private void nextSal(object parametar)
        {
            if (collSal[collSal.Count - 1] == Sal) return;

            for (int i = 0; i < collSal.Count - 1; i++)
                if (collSal[i] == Sal)
                {
                    Sal = collSal[i + 1];
                    View.PromijeniSelektiraniSal(i + 1);
                    return;
                }
        }

        private void nextPrivjesak(object parametar)
        {
            if (collPrivjesak[collPrivjesak.Count - 1] == Privjesak) return;

            for (int i = 0; i < collPrivjesak.Count - 1; i++)
                if (collPrivjesak[i] == Privjesak)
                {
                    Privjesak = collPrivjesak[i + 1];
                    View.PromijeniSelektiraniPrivjesak(i + 1);
                    return;
                }
        }

        private void izbaci(object parametar)
        {
            if (StavkaKorpa != null && StavkaKorpa.Proizvod != new Proizvod())
            {
                Korpa.Stavke.Remove(x => x.Proizvod.Id == StavkaKorpa.Proizvod.Id);
            }
        }

        private void plati(object parametar)
        {
            Plaćanje p = new Plaćanje();
            p.DataContext = new PlaćanjeViewModel(this, p);
            p.Show();
        }

        private bool ValidirajStavku(Stavka s, bool ima_velicinu = true)
        {
            if (s.Kolicina == 0 || s.Proizvod == null) return false;

            if (ima_velicinu)
                if (s.Velicina.ToUpper() != "S" && s.Velicina.ToUpper() != "M" && s.Velicina.ToUpper() != "L" && s.Velicina.ToUpper() != "XL") return false;

            return true; // ako nista ne prodje, onda je uredu
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
