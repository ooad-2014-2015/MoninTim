using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using FkHepekMobile.Resources;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace FkHepekMobile
{
    public partial class MainPage : PhoneApplicationPage
    {
        private List<Account> accounts;
        
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            UcitajAccounteIzJsona();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void UcitajAccounteIzJsona()
        {
            System.IO.Stream src = Application.GetResourceStream(new Uri("Resources/Accounts.json", UriKind.Relative)).Stream;
            using (StreamReader sr = new StreamReader(src))
            {
                string jsonText = sr.ReadToEnd();
                accounts = JsonConvert.DeserializeObject<List<Account>>(jsonText);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Account acc = accounts.FirstOrDefault(x => x.Username == tbUsername.Text && x.Password == tbPassword.Text);

            if (acc == null) 
                return;
            else
                NavigationService.Navigate(new Uri("/MenuIzbor.xaml?username=" + tbUsername.Text, UriKind.Relative));
        }

        private void tbUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text == "Username") tbUsername.Text = "";
        }

        private void tbUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text == "") tbUsername.Text = "Username";
        }

        private void tbPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbPassword.Text == "Password") tbPassword.Text = "";
        }

        private void tbPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbPassword.Text == "") tbPassword.Text = "Password";
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}