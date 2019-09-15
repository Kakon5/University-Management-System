using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Student
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter email address")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter contact no.")]
        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid number")]
        [DisplayName("Contact No")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please select an option")]
        [DisplayName("Student Reg. No.")]
        public string RegistrationNo { get; set; }
        public string Code  { get; set; }

        [Required(ErrorMessage = "Please select a department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public DateTime Date { get; set; }

        [DisplayName("Department")]
        public string DepartmentName { get; set; }
    }
}