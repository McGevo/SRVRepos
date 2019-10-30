using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SRV.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        string password = "Pass";
        string Username = "user";
        public LoginPage()
        {
            this.InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if (loginInput.Text == "" || LoginPassword.Text == "")
            {
                MessageDialog message = new MessageDialog(" please input username and password");
                await message.ShowAsync();
            }
            else if (loginInput.Text == Username && LoginPassword.Text == password)
            {
                Frame.Navigate(typeof(SummaryPage));
            }
            else
            {
                MessageDialog message = new MessageDialog(" please input correct username and password");
                await message.ShowAsync();
            }
        }
    }
}

