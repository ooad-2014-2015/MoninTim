﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FanShop.ViewModel
{
    class GlavnaFormaViewModel
    {
        private Clan clan;
        private GlavnaForma glavnaView; // view

        public GlavnaFormaViewModel(GlavnaForma gf)
        {
            clan = new Clan();
            glavnaView = gf;

            UserLogin = new RelayCommand(userLogin);
            AdminLogin = new RelayCommand(adminLogin);
            ModeratorLogin = new RelayCommand(moderatorLogin);
            Registracija = new RelayCommand(registracija);
            Gost = new RelayCommand(gost);
        }

        public Clan Clan
        {
            get { return clan; }
            set { clan = value; }
        }

        public ICommand UserLogin { get; set; }
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
                fs.DataContext = new WFanShopViewModel(fs);
                fs.Show();
                glavnaView.Hide();
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
            fs.Show();
            Gost g = new Gost();
            string s = g.generisiNick();
            fs.lab.Content = fs.lab.Content + "   " + s;
            glavnaView.Hide();
        }
    }
}