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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login1 : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }
        public Login1()
        {
            InitializeComponent();
            this.DataContext = new ViewModel.PrijavaViewModel(this);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Admin a = new Admin();
            a.Show();
            this.Hide();


        }
    }
}
