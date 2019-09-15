using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class SemesterManager
    {
        SemesterGateway aSemesterGateway = new SemesterGateway();

        public List<Semester> GetAllSemesters()
        {
            return aSemesterGateway.GetAllSemesters();

        } 
    }
}