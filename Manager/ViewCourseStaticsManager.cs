using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ViewCourseStaticsManager
    {
        ViewCourseStaticsGateway aViewCourseStaticsGateway = new ViewCourseStaticsGateway();

        public List<ViewCourseStatics> GetAllCourseStaticsByDepartment(int departmentId)
        {
            return aViewCourseStaticsGateway.GetAllCourseStaticsByDepartment(departmentId);
        }
    }
}