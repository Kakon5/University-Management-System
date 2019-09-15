using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ViewCourseStaticsGateway : Gateway
    {
        public List<ViewCourseStatics> GetAllCourseStaticsByDepartment(int departmentId)
        {
            Query = "SELECT *FROM GetCourseStatics Where DepartmentId=" +
                    departmentId;

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<ViewCourseStatics> courses = new List<ViewCourseStatics>();
            while (Reader.Read())
            {
                ViewCourseStatics courseStatics = new ViewCourseStatics();
                
                courseStatics.Name = Reader["CourseName"].ToString();
                courseStatics.Code = Reader["Code"].ToString();
                courseStatics.Semester = Reader["Semester"].ToString();
                courseStatics.TeacherName = Reader["TeacherName"].ToString();
                courses.Add(courseStatics);

            }
            Reader.Close();
            Connection.Close();
            return courses;
        }
    }
}