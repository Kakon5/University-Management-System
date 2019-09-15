using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class ViewCourseStatics
    {
        public int CourseId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public string Semester { get; set; }
        public int DepartmentId { get; set; }
        public string TeacherName { get; set; }
        public string Assigned { get; set; }


    }
}