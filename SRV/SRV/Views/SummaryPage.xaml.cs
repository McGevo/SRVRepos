using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SRV.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SummaryPage : Page
    {

        public SummaryPage()
        {
            this.InitializeComponent();

            string connString = "server=studentserver.com.au;user id=admin_srv-sdm;password=Passw0rd!@#;database=admin_it_studies_dev";
            MySqlConnection mySqlConn = new MySqlConnection(connString);
            try
            {
                mySqlConn.Open();

                string query = "SELECT * FROM competency";

                
                
            }
            catch
            {

            }

        }

        private void TranAppButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TranscriptApp));
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }


        public void BindGrid()
        {
            
        }
    }
}
