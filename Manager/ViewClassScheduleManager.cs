using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ViewClassScheduleManager
    {
        ViewClassScheduleGateway aScheduleGateway = new ViewClassScheduleGateway();

        public List<ViewClassSchedule> GetClassSchedules(int departmentId)
        {
            return aScheduleGateway.GetClassSchedules(departmentId);
        }
    }
}