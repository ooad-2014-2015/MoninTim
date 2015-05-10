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

namespace FanShop
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class GlavnaForma : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
        public GlavnaForma()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SignUp s = new SignUp();
            s.Show();
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Login1 l = new Login1();
            l.Show();
            this.Hide();
                
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Login2 l = new Login2();
            l.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WFanShop fs = new WFanShop();
            fs.Show();
            this.Hide();
        }
    }
}
