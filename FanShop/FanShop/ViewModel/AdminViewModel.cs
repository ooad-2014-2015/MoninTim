using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace FanShop.ViewModel
{
    class AdminViewModel
    {
        private ObservableCollection<Moderator> listaModeratora;
        private int moderatorId;

        private ObservableCollection<Clan> listaClanova;
        private int clanId;

        public AdminViewModel()
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka();
            listaModeratora = new ObservableCollection<Moderator>(bp.VratiUposlenike());
            listaClanova = new ObservableCollection<Clan>(bp.VratiClanove());
            Log = new List<string>(bp.VratiLog());

            DodajNovog = new RelayCommand(dodajNovog);
            ObrisiUposlenik = new RelayCommand(obrisiUposlenik);
            ObrisiClan = new RelayCommand(obrisiClan);
        }

        public ObservableCollection<Moderator> Moderatori
        {
            get { return listaModeratora; }
            set { listaModeratora = value; OnPropertyChanged("Moderatori"); }
        }

        public ObservableCollection<Clan> Clanovi
        {
            get { return listaClanova; }
            set { listaClanova = value; OnPropertyChanged("Clanovi"); }
        }

        // za brisanja
        public int ModeratorID
        {
            get { return moderatorId; }
            set { moderatorId = value; OnPropertyChanged("ModeratorID"); }
        }
        
        // za brisanja
        public int ClanID   
        {
            get { return clanId; }
            set { clanId = value; OnPropertyChanged("ClanID"); }
        }

        public List<string> Log { get; set; }

        public ICommand DodajNovog { get; set; }
        public ICommand ObrisiUposlenik { get; set; }
        public ICommand ObrisiClan { get; set; }

        private void dodajNovog(object parametar)
        {
            AddModerator am = new AddModerator();
            am.DataContext = new AddModeratorViewModel(this);
            am.Show();
        }

        private void obrisiUposlenik(object parametar)
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka();
            bp.ObrisiUposlenika(ModeratorID.ToString());
            this.Moderatori.Remove(x => x.Id == ModeratorID);
        }

        private void obrisiClan(object parametar)
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka();
            bp.ObrisiClana(ClanID.ToString());
            this.Clanovi.Remove(x => x.Id == ClanID);
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

    // stackoverflow rules !
    // napravljena još metoda .Remove() koja prima lambdu!
    public static class ExtensionMethods
    {
        public static int Remove<T>(
            this ObservableCollection<T> coll, Func<T, bool> condition)
        {
            var itemsToRemove = coll.Where(condition).ToList();

            foreach (var itemToRemove in itemsToRemove)
            {
                coll.Remove(itemToRemove);
            }

            return itemsToRemove.Count;
        }
    }
}
