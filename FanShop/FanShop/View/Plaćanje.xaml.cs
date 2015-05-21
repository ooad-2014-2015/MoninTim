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
    /// Interaction logic for Plaćanje.xaml
    /// </summary>
    public partial class Plaćanje : Window
    {
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
        public Plaćanje()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (check1.IsChecked.Value==true)
            {
                BrojKartice.Visibility = System.Windows.Visibility.Visible;
                Ccv.Visibility = System.Windows.Visibility.Visible;
                p.Visibility = System.Windows.Visibility.Visible;
                q.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void check1_Unchecked(object sender, RoutedEventArgs e)
        {
            BrojKartice.Visibility = System.Windows.Visibility.Hidden;
            Ccv.Visibility = System.Windows.Visibility.Hidden;
            p.Visibility = System.Windows.Visibility.Hidden;
            q.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
