using MySql.Data.MySqlClient;
using SRV.Models;
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
using Windows.UI.Popups;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Diagnostics;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SRV.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SummaryPage : Page
    {
        Unit newUnit = new Unit();
        List<Unit> unitList;
        Student student = LoginPage.student;
        List<string> qualList;

        string connString = "server=studentserver.com.au;user id=admin_srv-sdm;password=Passw0rd!@#;database=admin_it_studies_dev";
        public MySqlConnection mySqlConn;

        string query;
        MySqlCommand command;
        MySqlDataReader dReader;

        public SummaryPage()
        {
            this.InitializeComponent();

            
            double progressTracker = 0;


            //Valid Emails --> sally.smith@student.tafesa.edu.au or m_perez@hotmail.com

            unitList = newUnit.SelectUnits(student.Email);

            for (int i = 0; i < unitList.Count; i++)
            {
                if (unitList[i].Grade == "PA" || unitList[i].Grade == "P" || unitList[i].Grade == "C" || unitList[i].Grade == "D" || unitList[i].Grade == "HD")
                {
                    progressTracker++;
                }
            }
            double count = unitList.Count;
            double result = progressTracker / count;
            result = result * 100;

            if (progressTracker != 0)
                passBar.Value = result;
            else
                passBar.Value = 0;

            Qualification qual = new Qualification();
            qualList = qual.SelectQualifications(student.StudentID);
            qualComboBox.ItemsSource = qualList;

        }

        private void TranAppButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(TranscriptApp));
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }




            
            

    private void QualComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //unitList = newUnit.QualChanged(student.StudentID, qualComboBox.SelectedItem.ToString());
        }
    }
}
