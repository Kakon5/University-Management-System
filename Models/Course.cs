using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter department code")]
        [StringLength(100, MinimumLength = 5,
            ErrorMessage = "Code must be at least 5 characters long")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter course name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter credit")]
        [Range(0.5, 5.0, ErrorMessage = "Credit must be in between 0.5 to 5.0")]
        public double Credit { get; set; }

        [Required(ErrorMessage = "Please enter description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please select a department ")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please select a semester")]
        [DisplayName("Semester")]
        public int SemesterId { get; set; }

        public string SemesterName { get; set; }
        public string Assigned { get; set; }
    }
}