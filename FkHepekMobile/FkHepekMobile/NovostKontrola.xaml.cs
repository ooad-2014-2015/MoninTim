using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace FkHepekMobile
{
    public partial class NovostiKontrola : UserControl
    {
        public NovostiKontrola()
        {
            InitializeComponent();
        }

        public void PostaviNaslov(string naslov)
        {
            Naslov.Text = naslov;
        }

        public void PostaviSadrzaj(string tekst)
        {
            Tekst.Text = tekst;
        }
    }
}
