using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class SemesterGateway : Gateway
    {
        
        public List<Semester> GetAllSemesters()
        {
            Query = "SELECT * FROM Semester";

            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();

            List<Semester> semesters = new List<Semester>();

            while (Reader.Read())
            {
                Semester semester = new Semester();
                semester.Id = (int)Reader["Id"];
                semester.Name = Reader["Semester"].ToString();

                semesters.Add(semester);
            }
            Reader.Close();
            Connection.Close();

            return semesters;
        }
    }
}