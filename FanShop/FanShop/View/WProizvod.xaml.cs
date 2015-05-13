using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.IO;

namespace FanShop
{
    /// <summary>
    /// Interaction logic for WProizvod.xaml
    /// </summary>
    public partial class WProizvod : Window
    {
        public WProizvod()
        {
            InitializeComponent();
        }

         protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                string s = File.ReadAllText(ofd.FileName);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Baza.BazaPodataka bp = new Baza.BazaPodataka(); 
            
            if (rbSal.IsChecked == true)
            {
                bp.UnesiSal("slika??", tbCijena.Text);
            }
            else if (rbDres.IsChecked == true)
            {
                bp.UnesiDres("slika??", tbCijena.Text);
            }
            else if (rbKapa.IsChecked == true)
            {
                bp.UnesiKapu("slika??", tbCijena.Text);
            }
            else if (rbPrivjesak.IsChecked == true)
            {
                bp.UnesiPrivjesak("slika??", tbCijena.Text);
            }
        }

      
    }
}
