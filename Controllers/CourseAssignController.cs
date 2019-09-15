using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseAssignController : Controller
    {
        //
        // GET: /CourseAssign/

        TeacherManager aTeacherManager = new TeacherManager();
        CourseManager aCourseManager = new CourseManager();
        CourseAssignManager aCourseAssignManager = new CourseAssignManager();
        DepartmentManager aDepartmentManager = new DepartmentManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AssignCourse()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }

        [HttpPost]
        public ActionResult AssignCourse(CourseAssign aCourseAssign)
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            ViewBag.Message = aCourseAssignManager.AssignCourse(aCourseAssign);
            return View();
        }
        public JsonResult GetTeachers(int departmentId)
        {
            var teachers = aTeacherManager.GetTeachersByDepartment(departmentId);

            return Json(teachers);
        }
        public JsonResult GetCourses(int departmentId)
        {
            var courses = aCourseManager.GetCoursesByDepartmentId(departmentId);

            return Json(courses);
        }
        public JsonResult GetTeacherInformation(int teacherId)
        {
            var teacher = aTeacherManager.GetTeacherInformation(teacherId);

            return Json(teacher);
        }
        public JsonResult GetCourseInformation(int courseId)
        {
            var course = aCourseManager.GetCourseInformation(courseId);

            return Json(course);
        }

        public ActionResult UnassignCourse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnassignCourse(string unassignButton)
        {
            ViewBag.Message = aCourseAssignManager.UnassignAllCourses();
            return View();
        }
	}
}