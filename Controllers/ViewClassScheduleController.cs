using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ViewClassScheduleController : Controller
    {
        //
        // GET: /ViewClassSchedule/

        ViewClassScheduleManager aScheduleManager = new ViewClassScheduleManager();
        CourseManager aCourseManager = new CourseManager();
        DepartmentManager aDepartmentManager = new DepartmentManager();
        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewSchedules()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }
        public JsonResult GetClassSchedules(int departmentId)
        {
            var courses = aCourseManager.GetCoursesByDepartmentId(departmentId);
            var classSchedules = aScheduleManager.GetClassSchedules(departmentId);
            var allSchedules = GetAllClassSchedulesForTable(classSchedules, courses);
            return Json(allSchedules);
        }

        public List<ViewClassSchedule> GetAllClassSchedulesForTable(List<ViewClassSchedule> schedules, List<Course> courses)
        {
            foreach (Course course in courses)
            {
                int flag = 0;
                foreach (ViewClassSchedule aSchedule in schedules)
                {
                    if (aSchedule.CourseCode == course.Code)
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    ViewClassSchedule aViewClassSchedule = new ViewClassSchedule
                    {
                        CourseCode = course.Code,
                        CourseName = course.Name,
                        ScheduleInfo = "Not Scheduled Yet"
                    };
                    schedules.Add(aViewClassSchedule);
                }
            }
            return schedules;
        }

	}
}