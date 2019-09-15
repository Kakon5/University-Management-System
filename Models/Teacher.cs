using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a department")]
        [DisplayName("Department")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Please select a designation")]
        [DisplayName("Designation")]
        public int DesignationId { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Please enter email address")]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter contact no.")]
        [Range(0, long.MaxValue, ErrorMessage = "Please enter valid number")]
        [DisplayName("Contact No.")]
        public string ContactNo { get; set; }

        [Required(ErrorMessage = "Please enter credit")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Credit to be taken can't be a negative value")]
        [DisplayName("Credit to be taken")]
        public double CreditToBeTaken { get; set; }
        public double RemainingCredit { get; set; }
    }
}