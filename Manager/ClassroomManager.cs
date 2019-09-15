using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ClassroomManager
    {
        ClassroomGateway aClassroomGateway = new ClassroomGateway();

        public List<Classroom> GetAllClassrooms()
        {
            return aClassroomGateway.GetAllClassrooms();
        }
    }
}