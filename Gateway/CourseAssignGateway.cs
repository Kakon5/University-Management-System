using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class CourseAssignGateway : Gateway
    {
        
        public int AssignCourse(CourseAssign aCourseAssign)
        {
            Query = "INSERT INTO CourseAssign VALUES(@departmentId, @teacherId, @courseId, @assigned)";

            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("departmentId", aCourseAssign.DepartmentId);
            Command.Parameters.AddWithValue("teacherId", aCourseAssign.TeacherId);
            Command.Parameters.AddWithValue("courseId", aCourseAssign.CourseId);
            Command.Parameters.AddWithValue("assigned", "Yes");


            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            
            return rowAffected;
        }

        

        public bool IsCourseAssigned(int courseId)
        {
            Query = "SELECT *FROM CourseAssign WHERE Assigned = 'Yes' AND CourseId = " + courseId;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool assigned = false;
            if (Reader.HasRows)
            {
                assigned = true;
            }
            Reader.Close();
            Connection.Close();
            return assigned;
        }

        public int UnassignAllCourses()
        {
            Query = "UPDATE CourseAssign SET Assigned = 'No'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

    }
}