using SRV.Models;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SRV.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TranscriptApp : Page
    {
        Student student = LoginPage.student;
        
        public TranscriptApp()
        {

            this.InitializeComponent();

            fNameTBox.Text = student.FirstName;
            sNameTBox.Text = student.Surname;
            emailTBox.Text = student.Email;

            Qualification qual = new Qualification();
            List<string> qualList = qual.SelectQualifications(student.StudentID);
            qualBox.ItemsSource = qualList;
            idTBox.Text = student.StudentID;
        }

        

        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SummaryPage));
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LoginPage));
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            emailTBox.Text = "";
            phoneTBox.Text = "";
            idTBox.Text = "";
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            emailTBox.Text = "";
            phoneTBox.Text = "";
            idTBox.Text = "";
        }
    }
}
