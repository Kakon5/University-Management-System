using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class CourseEnrollGateway : Gateway
    {
        public int EnrollCourse(CourseEnroll aCourseEnroll)
        {
            Query = "INSERT INTO CourseEnroll VALUES("+ aCourseEnroll.StudentId +","+ aCourseEnroll.CourseId+
                ",'"+ aCourseEnroll.Date +"','Not Graded Yet')";

            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsCourseEnrolledByStudent(int studentId, int courseId)
        {
            Query = "SELECT *FROM CourseEnroll WHERE StudentId = " + studentId + "AND CourseId = " + courseId;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            bool hasRows = false;
            if (Reader.HasRows)
            {
                hasRows = true;
            }
            Reader.Close();
            Connection.Close();
            return hasRows;
        }

        public List<CourseEnroll> GetEnrolledCoursesByStudentId(int studentId)
        {
            Query = "SELECT *FROM GetEnrolledCoursesWithCourseName WHERE StudentId = " + studentId;
            Command = new SqlCommand(Query,Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            List<CourseEnroll> courseEnrolls = new List<CourseEnroll>();
            while (Reader.Read())
            {
                CourseEnroll aCourseEnroll = new CourseEnroll
                {
                    CourseId = (int) Reader["CourseId"],
                    CourseName = Reader["Name"].ToString()
                };
                courseEnrolls.Add(aCourseEnroll);
            }
            Reader.Close();
            Connection.Close();
            return courseEnrolls;
        }

        public int UpdateStudentGrade(CourseEnroll aCourseEnroll)
        {
            Query = "Update CourseEnroll SET Grade = '" + aCourseEnroll.Grade + 
                "' WHERE CourseId = " + aCourseEnroll.CourseId + " AND StudentId = " + aCourseEnroll.StudentId;

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}