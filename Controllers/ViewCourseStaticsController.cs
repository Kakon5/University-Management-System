using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ViewCourseStaticsController : Controller
    {
        //
        // GET: /ViewCourseStatics/

        ViewCourseStaticsManager aCourseStaticsManager = new ViewCourseStaticsManager();
        CourseManager aCourseManager = new CourseManager();
        DepartmentManager aDepartmentManager = new DepartmentManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewCourses()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }

        public JsonResult GetCourseStatics(int departmentId)
        {
            var courses = aCourseManager.GetCoursesWithSemesterByDepartmentId(departmentId);
            var courseStatics = aCourseStaticsManager.GetAllCourseStaticsByDepartment(departmentId);
            var allCourseStatics = GetAllCourseStaticsForTable(courseStatics, courses);
            return Json(allCourseStatics);
        }

        public List<ViewCourseStatics> GetAllCourseStaticsForTable(List<ViewCourseStatics> courseStatics, List<Course> courses)
        {
            foreach (Course course in courses)
            {
                int flag = 0;
                foreach (ViewCourseStatics aCourseStatic in courseStatics)
                {
                    if (aCourseStatic.Code == course.Code)
                    {
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    ViewCourseStatics courseStatic = new ViewCourseStatics
                    {
                        Code = course.Code,
                        Name = course.Name,
                        TeacherName = "Not Assigned Yet",
                        Semester = course.SemesterName
                    };
                    courseStatics.Add(courseStatic);
                }
            }
            return courseStatics;
        }
	}
}