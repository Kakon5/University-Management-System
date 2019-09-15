using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class DepartmentController : Controller
    {
        //
        // GET: /Department/
        public ActionResult Index()
        {
            return View();
        }

        DepartmentManager aDepartmentManager = new DepartmentManager();
        public ActionResult SaveDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveDepartment(Department department)
        {
            ViewBag.Message = aDepartmentManager.Save(department);

            return View();
        }

        public ActionResult ViewDepartments()
        {
            ViewBag.Departments = aDepartmentManager.GetAllDepartments();
            return View();
        }
	}
}