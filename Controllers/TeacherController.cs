using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class TeacherController : Controller
    {
        //
        // GET: /Teacher/

        TeacherManager aTeacherManager = new TeacherManager();
        DepartmentManager aDepartmentManager = new DepartmentManager();
        DesignationManager aDesignationManager = new DesignationManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveTeacher()
        {
            ViewBag.Departments = GetDepartmentsForDropDownList();
            ViewBag.Designations = GetDesignationsForDropDownList();
            return View();
        }
        [HttpPost]
        public ActionResult SaveTeacher(Teacher aTeacher)
        {
            ViewBag.Departments = GetDepartmentsForDropDownList();
            ViewBag.Designations = GetDesignationsForDropDownList();
            ViewBag.Message = aTeacherManager.SaveTeacher(aTeacher);

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

        public List<SelectListItem> GetDesignationsForDropDownList()
        {
            var designations = aDesignationManager.GetAllDesignations();
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "",Text = "--Select Designation--"
                }
            };
            foreach (Designation aDesignation in designations)
            {
                SelectListItem item = new SelectListItem()
                {
                    Value = aDesignation.Id.ToString(),
                    Text = aDesignation.Name
                };

                items.Add(item);
            }

            return items;
        } 
	}
}