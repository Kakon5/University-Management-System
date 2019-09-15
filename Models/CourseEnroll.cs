using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class CourseEnroll
    {
        public int  Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public DateTime Date { get; set; }
        public string Grade { get; set; }
    }
}