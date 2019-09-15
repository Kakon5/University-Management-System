using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ResultGateway : Gateway
    {
        public List<Result> GetResultsByStudentId(int id)
        {
            Query = "SELECT *FROM GetStudentsResultWithCourseName WHERE StudentId = " + id;
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            List<Result> results = new List<Result>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Result aResult = new Result
                {
                    CourseCode = Reader["CourseCode"].ToString(),
                    CourseName = Reader["CourseName"].ToString(),
                    Grade = Reader["Grade"].ToString(),
                    Credit = Convert.ToDouble(Reader["Credit"])
                };
                results.Add(aResult);
            }
            return results;
        } 
    }
}