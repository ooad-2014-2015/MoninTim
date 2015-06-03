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
    public partial class MenuIzbor : PhoneApplicationPage
    {
        private string username;

        public MenuIzbor()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            username = NavigationContext.QueryString["username"];
            tbHeader.Text = "Zdravo, " + username;
        }

        private void btnNovosti_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainUser.xaml", UriKind.Relative));
        }

        private void btnTabela_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainUser2.xaml", UriKind.Relative));
        }
    }
}