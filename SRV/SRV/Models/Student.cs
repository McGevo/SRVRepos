using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SRV.Models
{
    public class Student
    {
        public string StudentID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        //string connString = "server=studentserver.com.au;user id=admin_srv-sdm;password=Passw0rd!@#;database=admin_it_studies_dev";
        //public MySqlConnection mySqlConn;

        //string query;
        //MySqlCommand command;
        //MySqlDataReader dReader;

        public Student(string studentID, string firstName, string surname, string email)
        {
            StudentID = studentID;
            FirstName = firstName;
            Surname = surname;
            Email = email;
        }

        public Student()
        {
            StudentID = "";
            FirstName = "";
            Surname = "";
            Email = "";
        }

        //  public Student(string email) { 
        //     // mySqlConn = new MySqlConnection(connString);
        //   //   query = "SELECT * FROM student WHERE EmailAddress = '" + email + "'";
        //  //    command = new MySqlCommand(query, mySqlConn);
        ////      mySqlConn.Open();
        //      string studentID = "";
        //      string firstName = "";
        //      string surname = "";
        //      string emailAddress = "";
        //      dReader = command.ExecuteReader();
        //      while (dReader.Read()){ 
        //          studentID = dReader.GetValue(0).ToString();
        //          firstName = dReader.GetValue(1).ToString();
        //          surname = dReader.GetValue(2).ToString();
        //          emailAddress = dReader.GetValue(3).ToString();
        //     }


        //    Student student = new Student(studentID, firstName, surname, emailAddress);
        //}

        public override string ToString()
        {
            return this.FirstName + " " + this.Surname;
        }


    }
}
