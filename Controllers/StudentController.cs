using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Student/
        public ActionResult Index()
        {
            return View();
        }

        DepartmentManager aDepartmentManager = new DepartmentManager();
        StudentManager aStudentManager = new StudentManager();
        public ActionResult RegisterStudent()
        {
            ViewBag.Departments = GetDepartmentsForDropDownList();
            return View();
        }
        [HttpPost]
        public ActionResult RegisterStudent(Student aStudent)
        {
            ViewBag.Departments = GetDepartmentsForDropDownList();

            if (aStudentManager.IsEmailExists(aStudent.Email))
            {
                ViewBag.Message = "Email already exists!";
            }
            else
            {
                aStudent.DepartmentCode = aDepartmentManager.FindDepartmentCode(aStudent.DepartmentId);
                Student student = aStudentManager.SaveStudent(aStudent);
                if (student != null)
                {
                    ViewBag.Student = student;
                }
                else
                {
                    ViewBag.Message = "Registration Failed!";
                }

            }
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

	}
}