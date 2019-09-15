using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class DesignationManager
    {
        DesignationGateway aDesignationGateway = new DesignationGateway();

        public List<Designation> GetAllDesignations()
        {
            return aDesignationGateway.GetAllDesignations();
        }
    }
}