using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ClassroomAllocateGateway : Gateway
    {
        public bool IsPossibleToAllocate(ClassroomAllocate aClassroomAllocate)
        {
            Query = "SELECT *FROM ClassroomAllocate WHERE ClassroomId = " + aClassroomAllocate.ClassroomId +
                    "AND Day = '" + aClassroomAllocate.Day + "' AND Allocated = 'Yes'";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            
            while (Reader.Read())
            {

                string startTime = Reader["StartTime"].ToString();
                string endTime = Reader["EndTime"].ToString();

                if (IsTimeOverlapped(startTime, endTime, aClassroomAllocate))
                {
                    Connection.Close();
                    return false;
                }
            }
            Connection.Close();
            return true;
        }

        private bool IsTimeOverlapped(string startTime, string endTime, ClassroomAllocate aClassroomAllocate)
        {
            DateTime previousStartTime = DateTime.Parse(startTime);
            DateTime previousEndTime = DateTime.Parse(endTime);
            DateTime newStartTime = DateTime.Parse(aClassroomAllocate.StartTime);
            DateTime newEndTime = DateTime.Parse(aClassroomAllocate.EndTime);

            if (newEndTime.TimeOfDay <= previousStartTime.TimeOfDay ||
                newStartTime.TimeOfDay >= previousEndTime.TimeOfDay)
            {
                return false;
            }
            return true;
        }

        public int AllocateClassroom(ClassroomAllocate aClassroomAllocate)
        {
            Query = "INSERT INTO ClassroomAllocate VALUES(@departmentId,@classroomId,@courseId,@day,@startTime,@endTime,@allocated)";

            Command = new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("departmentId", aClassroomAllocate.DepartmentId);
            Command.Parameters.AddWithValue("classroomId", aClassroomAllocate.ClassroomId);
            Command.Parameters.AddWithValue("courseId", aClassroomAllocate.CourseId);
            Command.Parameters.AddWithValue("day", aClassroomAllocate.Day);
            Command.Parameters.AddWithValue("startTime", aClassroomAllocate.StartTime);
            Command.Parameters.AddWithValue("endTime", aClassroomAllocate.EndTime);
            Command.Parameters.AddWithValue("allocated", "Yes");

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;

        }

        public int UnallocateAllClassrooms()
        {
            Query = "UPDATE ClassroomAllocate SET Allocated = 'No'";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }
    }
}