using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SRV.Models
{
    class Unit 
    {
        public string SubjectCode { get; set; }
        public string SubjectDesc { get; set; }
        public string Grade { get; set; }
        public string NationalCode { get; set; }


        string connString = "server=studentserver.com.au;user id=admin_srv-sdm;password=Passw0rd!@#;database=admin_it_studies_dev";
        public MySqlConnection mySqlConn;

        string query;
        MySqlCommand command;
        MySqlDataReader dReader;

        public Unit()
        {
            SubjectCode = "Null";
            SubjectDesc = "Null";
            Grade = "NA";
        }

        public Unit(string subjectCode, string subjectDesc, string grade, string nationalCode)
        {
            SubjectCode = subjectCode;
            SubjectDesc = subjectDesc;
            NationalCode = nationalCode;
            Grade = grade;
        }

        public List<Unit> SelectUnits(string email)
        {
            string[] subjectCode = new string[100];
            string[] subjectDesc = new string[100];
            string[] grade = new string[100];
            string[] nationalCode = new string[100];
            string studentID = "";
            string[] crn = new string[100];
            List<Unit> units = new List<Unit>();
            int tracker = 0;

            mySqlConn = new MySqlConnection(connString);
            query = "SELECT student.StudentID FROM student_grade JOIN student WHERE EmailAddress = '" + email + "'";
            command = new MySqlCommand(query, mySqlConn);
            mySqlConn.Open();
            dReader = command.ExecuteReader();
            int i = 0;

            while (dReader.Read())
            {
                studentID = dReader.GetValue(0).ToString();
            }

            mySqlConn.Close();

            query = "SELECT subject.SubjectCode, SubjectDescription, Grade, NationalCompCode FROM student_grade INNER JOIN crn_detail ON student_grade.CRN = crn_detail.CRN INNER JOIN subject ON crn_detail.SubjectCode = subject.SubjectCode INNER JOIN competency ON crn_detail.TafeCompCode = competency.TafeCompCode WHERE StudentID = " + studentID;
            command = new MySqlCommand(query, mySqlConn);
            mySqlConn.Open();
            dReader = command.ExecuteReader();

            i = 0; 
            while (dReader.Read())
            {
                subjectCode[i] = dReader.GetValue(0).ToString();
                subjectDesc[i] = dReader.GetValue(1).ToString();
                grade[i] = dReader.GetValue(2).ToString();
                nationalCode[i] = dReader.GetValue(3).ToString();

                i++;
                tracker++;
            }

            for (i = 0; i < tracker; i++)
            {

                units.Add(new Unit(subjectCode[i], subjectDesc[i], grade[i], nationalCode[i]));
            }

           

            return units;
        }



        public override string ToString()
        {
            return "Code = " + this.SubjectCode + ", Description = " + this.SubjectDesc + ", Grade = " + Grade + "\n";
        }
    }

}
