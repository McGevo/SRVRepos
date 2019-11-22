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


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SRV.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SummaryPage : Page
    {
        List<Unit> unitList;
        public SummaryPage()
        {
            this.InitializeComponent();

            Unit newUnit = new Unit();
            double progressTracker = 0;

            unitList = newUnit.SelectUnits("sally.smith@student.tafesa.edu.au");

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

        private async void RandomButton_Click(object sender, RoutedEventArgs e)
        {
            Unit unit = new Unit();

            List<Unit> units = unit.SelectUnits("m_perez@hotmail.com");

            string unitThing = units[0].ToString();

            int i = 0;
            while (i < 12)
            {
                unitThing += units[i].ToString();
                i++;
            }

            MessageDialog message = new MessageDialog(unitThing);
            await message.ShowAsync();
        }
    }
}
