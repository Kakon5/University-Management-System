using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class ClassroomAllocate
    {
        public int Id { get; set; }

         [Required(ErrorMessage = "Please select a department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please select a room")]
        [DisplayName("Room No.")]
        public int ClassroomId { get; set; }

        [Required(ErrorMessage = "Please select a course")]
        [DisplayName("Course")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Please select a day")]
        public string Day { get; set; }

        [Required(ErrorMessage = "Please enter start time")]
        [RegularExpression(@"^(0[1-9]|1[0-2]):[0-5][0-9] (am|pm|AM|PM)$", ErrorMessage = "Invalid Time.")]
        [DisplayName("From")]
        public string StartTime { get; set; }
       

        [Required(ErrorMessage = "Please enter finish time")]
        [RegularExpression(@"^(0[1-9]|1[0-2]):[0-5][0-9] (am|pm|AM|PM)$", ErrorMessage = "Invalid Time.")]
        [DisplayName("To")]
        public string EndTime { get; set; }
       
        public string Allocated { get; set; }
    }
}