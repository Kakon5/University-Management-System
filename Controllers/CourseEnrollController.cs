using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseEnrollController : Controller
    {
        //
        // GET: /CourseEnroll/
        public ActionResult Index()
        {
            return View();
        }

        StudentManager aStudentManager = new StudentManager();
        CourseManager aCourseManager = new CourseManager();
        CourseEnrollManager aCourseEnrollManager = new CourseEnrollManager();
        public ActionResult EnrollCourse()
        {
            ViewBag.Students = aStudentManager.GetAllStudents();
            return View();
        }
        [HttpPost]
        public ActionResult EnrollCourse(CourseEnroll aCourseEnroll)
        {
            ViewBag.Students = aStudentManager.GetAllStudents();
            ViewBag.Message = aCourseEnrollManager.EnrollCourse(aCourseEnroll);
            return View();
        }
        public JsonResult GetCourses(int studentId)
        {
            var student = aStudentManager.GetStudentInformationByStudentId(studentId);
            var courses = aCourseManager.GetCoursesByDepartmentId(student.DepartmentId);

            return Json(courses);
        }
        public JsonResult GetStudentInformation(int studentId)
        {
            var student = aStudentManager.GetStudentInformationByStudentId(studentId);
            return Json(student);
        }
	}
}