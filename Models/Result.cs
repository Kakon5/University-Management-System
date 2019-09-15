using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Result
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double Credit { get; set; }
        public string Grade { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
    }
}