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
using SRV.Models;
using Windows.UI.Popups;
using MySql.Data.MySqlClient;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SRV.Views
{
    
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        public static Student student;

        public LoginPage()
        {
            this.InitializeComponent();
        }


        string connString = "server=studentserver.com.au;user id=admin_srv-sdm;password=Passw0rd!@#;database=admin_it_studies_dev";
        public MySqlConnection mySqlConn;

        string query;
        MySqlCommand command;
        MySqlDataReader dReader;

        private void TextBox_TextChanged(System.Object sender, TextChangedEventArgs e)
        {

        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {

            mySqlConn = new MySqlConnection(connString);
            query = "SELECT * FROM student WHERE EmailAddress = '" + loginInput.Text + "'";
            command = new MySqlCommand(query, mySqlConn);
            mySqlConn.Open();



            string studentID = "";
            string firstName = "";
            string surname = "";
            string emailAddress = "";

            dReader = command.ExecuteReader();
            while (dReader.Read())
            {

                studentID = dReader.GetValue(0).ToString();
                firstName = dReader.GetValue(1).ToString();
                surname = dReader.GetValue(2).ToString();
                emailAddress = dReader.GetValue(3).ToString();


            }
            student = new Student(studentID, firstName, surname, emailAddress);
            if (loginInput.Text == emailAddress && loginInput.Text != "")
            {
                Frame.Navigate(typeof(SummaryPage), student);
            }
            else
            {
                MessageDialog m = new MessageDialog("invalid userName");
                await m.ShowAsync();

            }
        }
    }
}