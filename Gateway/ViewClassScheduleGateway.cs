using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ViewClassScheduleGateway : Gateway
    {
        List<ViewClassSchedule> schedules = new List<ViewClassSchedule>();
        public List<ViewClassSchedule> GetClassSchedules(int departmentId)
        {
            Query = "SELECT *FROM GetClassScheduleInformation WHERE DepartmentId = " + departmentId;
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                ViewClassSchedule aSchedule = new ViewClassSchedule();

                aSchedule.CourseCode = Reader["CourseCode"].ToString();
                aSchedule.CourseName = Reader["CourseName"].ToString();
                aSchedule.Day = Reader["Day"].ToString();
                aSchedule.StartTime = Reader["StartTime"].ToString();
                aSchedule.EndTime = Reader["EndTime"].ToString();
                aSchedule.RoomNo = Reader["RoomNo"].ToString();

                aSchedule.ScheduleInfo = "R. No : " + aSchedule.RoomNo + ", " + aSchedule.Day + ", " +
                                         aSchedule.StartTime + " - " + aSchedule.EndTime;
                if (!IsCourseExistsInList(aSchedule))
                {
                    schedules.Add(aSchedule);
                }
                
            }
            return schedules;
        }

        public bool IsCourseExistsInList(ViewClassSchedule aSchedule)
        {
            foreach (ViewClassSchedule schedule in schedules)
            {
                if (schedule.CourseCode == aSchedule.CourseCode)
                {
                    schedule.ScheduleInfo = schedule.ScheduleInfo + "; " + aSchedule.ScheduleInfo;
                    
                    return true;
                }
            }
            return false;
        }
    }

}