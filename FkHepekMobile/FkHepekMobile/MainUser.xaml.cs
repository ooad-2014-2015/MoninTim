using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Newtonsoft.Json;
using System.IO;
using FkHepekMobile.Resources;

namespace FkHepekMobile
{
    public partial class MainUser : PhoneApplicationPage
    {
        private List<Novost> novosti;

        public MainUser()
        {
            InitializeComponent();
            UcitajNovosti();
        }

        private void UcitajNovosti()
        {
            UcitajIzJsona();

            foreach (var novost in novosti)
            {
                PivotItem p = new PivotItem();
                NovostiKontrola nk = new NovostiKontrola();

                nk.PostaviNaslov(novost.Naslov);
                nk.PostaviSadrzaj(novost.Sadrzaj);

                p.Header = novost.Datum;
                p.Content = nk;

                GlavniPivot.Items.Add(p);
            }
        }

        private void UcitajIzJsona()
        { 
            System.IO.Stream src = Application.GetResourceStream(new Uri("Resources/Novosti.json", UriKind.Relative)).Stream;
            using (StreamReader sr = new StreamReader(src))
            {
                string jsonText = sr.ReadToEnd();
                novosti = JsonConvert.DeserializeObject<List<Novost>>(jsonText);
            }
        }
    }
}