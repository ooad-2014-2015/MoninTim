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
using System.Drawing;

namespace FanShop
{
    /// <summary>
    /// Interaction logic for FanShop.xaml
    /// </summary>
    public partial class WFanShop : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
         
            

            Application.Current.Shutdown();
        }
        public WFanShop()
        {
            InitializeComponent();
        }

        public void PromijeniSelektiraniDres(int i) 
        {
            cbDresovi.SelectedIndex = i;
        }

        public void PromijeniSelektiranuKapu(int i)
        {
            cbKape.SelectedIndex = i;
        }

        public void PromijeniSelektiraniSal(int i)
        {
            cbSalovi.SelectedIndex = i;
        }

        public void PromijeniSelektiraniPrivjesak(int i)
        {
            cbPrivjesci.SelectedIndex = i;
        }

        private void cbDresovi_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
        
        }
    }
}
