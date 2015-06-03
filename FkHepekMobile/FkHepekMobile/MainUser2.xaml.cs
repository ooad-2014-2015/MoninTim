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
    public partial class MainUser2 : PhoneApplicationPage
    {
        private List<Tim> tabela;
        private List<Igrac> statistika;

        public MainUser2()
        {
            InitializeComponent();
            
            UcitajTabelu();
            IspisiTabelu();

            UcitajStatistiku();
            IspisiStatistiku();
        }

        private void UcitajTabelu()
        {
            System.IO.Stream src = Application.GetResourceStream(new Uri("Resources/Tabela.json", UriKind.Relative)).Stream;
            using (StreamReader sr = new StreamReader(src))
            {
                string jsonText = sr.ReadToEnd();
                tabela = JsonConvert.DeserializeObject<List<Tim>>(jsonText);
            }
        }

        private void IspisiTabelu()
        {
            int i = 1;
            foreach (var T in tabela)
            {
                tbTabela.Text += i.ToString() + ". ";
                tbTabela.Text += T.ToString() + Environment.NewLine + Environment.NewLine;
                i++;
            }
        }

        private void UcitajStatistiku()
        {
            System.IO.Stream src = Application.GetResourceStream(new Uri("Resources/Statistika.json", UriKind.Relative)).Stream;
            using (StreamReader sr = new StreamReader(src))
            {
                string jsonText = sr.ReadToEnd();
                statistika = JsonConvert.DeserializeObject<List<Igrac>>(jsonText);
            }
        }

        private void IspisiStatistiku()
        {
            tbStrijelac.Text = statistika[0].Ime + " (Golova " + statistika[0].Status + ")";
            tbAsistent.Text = statistika[1].Ime + " (Asistencija " + statistika[1].Status + ")";
            tbEfikasan.Text = statistika[2].Ime + " (Pr. ocjena " + statistika[2].Status + ")";
        }
    }
}