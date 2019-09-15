using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class CourseGateway : Gateway
    {
        public int Save(Course course)
        {
            
            Query = "INSERT INTO Course VALUES(@code,@name,@credit,@description,@departmentid,@semesterid)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Code", course.Code);
            Command.Parameters.AddWithValue("name", course.Name);
            Command.Parameters.AddWithValue("credit", course.Credit);
            Command.Parameters.AddWithValue("description", course.Description);
            Command.Parameters.AddWithValue("departmentid", course.DepartmentId);
            Command.Parameters.AddWithValue("semesterid", course.SemesterId);
            

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
        public bool IsCodeExits(string Code)
        {
            Connection = new SqlConnection(connectionString);
            Query = "SELECT * FROM Course WHERE Code=  @code";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("code", Code);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            bool hasRow = false;
            if (reader.HasRows)
            {
                hasRow = true;
            }
            reader.Close();
            Connection.Close();
            return hasRow;
        }
        public bool IsNameExits(string Name)
        {
            Connection = new SqlConnection(connectionString);
            Query = "SELECT * FROM Course WHERE Name= @name";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("name", Name);

            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            bool hasRow = false;
            if (reader.HasRows)
            {
                hasRow = true;
            }
            reader.Close();
            Connection.Close();
            return hasRow;
        }

        public List<Course> GetallCourses()
        {
            Query = "SELECT *FROM Course";
            Command = new SqlCommand(Query,Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();

            while (Reader.Read())
            {
                Course aCourse = new Course
                {
                    Id = (int) Reader["Id"],
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString(),
                    Credit = Convert.ToDouble(Reader["Credit"]),
                    Description = Reader["Description"].ToString(),
                    Assigned = Reader["Assigned"].ToString(),
                    SemesterId = (int)Reader["SemesterId"],
                    DepartmentId = (int)Reader["DepartmentId"],
                };
                courses.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        

        public List<Course> GetCoursesByDepartmentId(int departmentId)
        {
            Query = "SELECT *FROM Course WHERE DepartmentId = " + departmentId;
            Command = new SqlCommand(Query,Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();

            while (Reader.Read())
            {
                Course aCourse = new Course
                {
                    Id = (int)Reader["Id"],
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString()
                };
                courses.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public List<Course> GetCoursesWithSemesterByDepartmentId(int departmentId)
        {
            Query = "SELECT *FROM GetCoursesWithSemester WHERE DepartmentId = " + departmentId;
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Course> courses = new List<Course>();

            while (Reader.Read())
            {
                Course aCourse = new Course
                {
                    
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString(),
                    SemesterName = Reader["Semester"].ToString()
                };
                courses.Add(aCourse);
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public Course GetCourseInformation(int courseId)
        {
            Query = "SELECT *FROM Course WHERE Id = " + courseId;
            Command = new SqlCommand(Query, Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();
            Course course = new Course();

            while (Reader.Read())
            {
                course.Name = Reader["Name"].ToString();
                course.Credit = Convert.ToDouble(Reader["Credit"]);

            }
            Reader.Close();
            Connection.Close();
            return course;
        }
    }
}