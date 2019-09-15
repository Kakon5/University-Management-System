using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementSystem.Models
{
    public class Semester
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please select semester")]
        public string Name { get; set; }
    }
}