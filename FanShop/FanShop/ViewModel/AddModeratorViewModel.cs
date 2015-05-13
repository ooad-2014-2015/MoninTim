using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FanShop.ViewModel
{
    class AddModeratorViewModel
    {
        private Moderator mod;
        private AdminViewModel parent;

        public AddModeratorViewModel(AdminViewModel p)
        {
            this.parent = p;
            Dodaj = new RelayCommand(dodaj);
            mod = new Moderator();
        }

        public AdminViewModel Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public Moderator Moderator
        {
            get { return mod; }
            set { mod = value; }
        }

        public ICommand Dodaj { get; set; }
        public Action CloseAction { get; set; }

        private void dodaj(object parametar)
        {
            if (this.mod.IsValid )
            {
                Baza.BazaPodataka bp = new Baza.BazaPodataka();
                Moderator.Id = bp.UnesiUposlenika(mod.Username, mod.Password, mod.Ime_prezime);
                this.Parent.Moderatori.Add(this.Moderator);
            }
            else
            {
                System.Windows.MessageBox.Show("Pokušavate unijeti pogrešne podatke");
            }
        }
    }
}
