using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.Models
{
    class Qualification
    {

        public string QualCode { get; set; }
        public string QualName { get; set; }

        string connString = "server=studentserver.com.au;user id=admin_srv-sdm;password=Passw0rd!@#;database=admin_it_studies_dev";
        public MySqlConnection mySqlConn;

        string query;
        MySqlCommand command;
        MySqlDataReader dReader;

        public Qualification()
        {
            QualCode = "NULL";
            QualName = "NULL";
        }

        public Qualification(string qualCode, string qualName)
        {
            QualCode = qualCode;
            QualName = qualName;
        }

        public Qualification(string qualName)
        {
            QualName = qualName;
            mySqlConn = new MySqlConnection(connString);
            query = "SELECT QualCode FROM qualification WHERE QualName = '" + qualName + "'";
            command = new MySqlCommand(query, mySqlConn);
            mySqlConn.Open();
            dReader = command.ExecuteReader();
            while (dReader.Read())
            {
                QualCode = dReader.GetValue(0).ToString();

            }
        }

        public List<string> SelectQualifications(string studentID)
        {
            string[] qualCode = new string[100];
            string[] qualName = new string[100];

            List<string> qualifications = new List<string>();
            int tracker = 0;

            mySqlConn = new MySqlConnection(connString);
            query = "SELECT QualName FROM qualification JOIN student_studyplan ON qualification.QualCode = student_studyplan.QualCode WHERE StudentID = '" + studentID + "'";
            command = new MySqlCommand(query, mySqlConn);
            mySqlConn.Open();
            dReader = command.ExecuteReader();
            int i = 0;
            while (dReader.Read())
            {
                qualName[i] = dReader.GetValue(0).ToString();

                i++;
                tracker++;
            }

            for (i = 0; i < tracker; i++)
            {

                qualifications.Add(qualName[i]);
            }



            return qualifications;
        }
    }
}
