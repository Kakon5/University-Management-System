using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        //
        // GET: /Course/
        public ActionResult Index()
        {
            return View();
        }

        CourseManager aCourseManager = new CourseManager();
        DepartmentManager aDepartmentManager = new DepartmentManager();
        SemesterManager aSemesterManager = new SemesterManager();
        public ActionResult SaveCourse()
        {
            ViewBag.Departments = GetDepartmentsForDropDownList();
            ViewBag.Semesters = GetSemestersForDropDownList();

            //ViewBag.Courses = aCourseManager.GetallCourses();
            return View();
        }

        [HttpPost]
        public ActionResult SaveCourse(Course course)
        {
            ViewBag.Departments = GetDepartmentsForDropDownList();
            ViewBag.Semesters = GetSemestersForDropDownList();

            ViewBag.Message = aCourseManager.Save(course);
            return View();
        }

        public List<SelectListItem> GetDepartmentsForDropDownList()
        {
            var departments = aDepartmentManager.GetAllDepartments();
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "",Text = "--Select Department--"
                }
            };
            foreach (var department in departments)
            {
                SelectListItem item = new SelectListItem()
                {
                    Value = department.Id.ToString(),
                    Text = department.Name
                };

                items.Add(item);
            }

            return items;
        }
        public List<SelectListItem> GetSemestersForDropDownList()
        {
            var semesters = aSemesterManager.GetAllSemesters();
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "",Text = "--Select Semester--"
                }
            };
            foreach (var semester in semesters)
            {
                SelectListItem item = new SelectListItem()
                {
                    Value = semester.Id.ToString(),
                    Text = semester.Name
                };

                items.Add(item);
            }

            return items;
        } 

	}
}