using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class ViewClassSchedule
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }

        public string Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Allocated { get; set; }
        public string RoomNo { get; set; }
        public string ScheduleInfo { get; set; }

    }
}