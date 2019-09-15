using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateway = new DepartmentGateway();

        public string Save(Department department)
        {
            if (aDepartmentGateway.IsCodeExits(department.Code))
            {
                return "Department code already exists!";
            }
            else if (aDepartmentGateway.IsNameExits(department.Name))
            {
                return "Department name already exists!";
            }
            int rowAffected = aDepartmentGateway.Save(department);
            if (rowAffected > 0)
            {
                return "Department is successfully Saved!";
            }
            return "Department couldn't be saved!";
        }

        public List<Department> GetAllDepartments()
        {
            return aDepartmentGateway.GetAllDepartments();
        }

        public string FindDepartmentCode(int id)
        {
            return aDepartmentGateway.FindDepartmentCode(id);
        }

        public string FindDepartmentName(int id)
        {
            return aDepartmentGateway.FindDepartmentName(id);
        }
    }
}