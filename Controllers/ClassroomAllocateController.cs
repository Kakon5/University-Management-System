using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Controllers
{
    public class ClassroomAllocateController : Controller
    {
        //
        // GET: /ClassroomAllocate/

        DepartmentManager aDepartmentManager = new DepartmentManager();
        ClassroomManager aClassroomManager = new ClassroomManager();
        CourseManager aCourseManager = new CourseManager();
        ClassroomAllocateManager aClassroomAllocateManager = new ClassroomAllocateManager();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllocateClassroom()
        {
            ViewBag.Departments = GetDepartmentsForDropDownList();

            ViewBag.Classrooms = GetClassroomsForDropDownList();
            ViewBag.Days = GetDaysForDropDownList();
            return View();
        }
        [HttpPost]
        public ActionResult AllocateClassroom(ClassroomAllocate aClassroomAllocate)
        {
            ViewBag.Departments = GetDepartmentsForDropDownList();

            ViewBag.Classrooms = GetClassroomsForDropDownList();
            ViewBag.Days = GetDaysForDropDownList();
            ViewBag.Message = aClassroomAllocateManager.AllocateClassroom(aClassroomAllocate);
            return View();
        }

        public ActionResult UnallocateClassroom()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UnallocateClassroom(string unallocateButton)
        {
            ViewBag.Message = aClassroomAllocateManager.UnallocateAllClassrooms();
            return View();
        }

        public JsonResult GetCoursesByDepartmentId(int departmentId)
        {
            var courses = aCourseManager.GetCoursesByDepartmentId(departmentId);

            return Json(courses);
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

        public List<SelectListItem> GetClassroomsForDropDownList()
        {
            var classrooms = aClassroomManager.GetAllClassrooms();
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "",Text = "--Select Classroom--"
                }
            };
            foreach (var classroom in classrooms)
            {
                SelectListItem item = new SelectListItem()
                {
                    Value = classroom.Id.ToString(),
                    Text = classroom.RoomNo
                };

                items.Add(item);
            }

            return items;
        }

        public List<SelectListItem> GetCoursesForDropDownList()
        {
            var courses = aCourseManager.GetallCourses();
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "",Text = "--Select Course--"
                }
            };
            foreach (var course in courses)
            {
                SelectListItem item = new SelectListItem()
                {
                    Value = course.Id.ToString(),
                    Text = course.Name
                };

                items.Add(item);
            }

            return items;
        }
        public List<SelectListItem> GetDaysForDropDownList()
        {

            List<SelectListItem> days = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Value = "",Text = "--Select Day--"
                },
                new SelectListItem()
                {
                    Value = "Sunday",Text = "Sunday"
                },
                new SelectListItem()
                {
                    Value = "Monday",Text = "Monday"
                },
                new SelectListItem()
                {
                    Value = "Tuesday",Text = "Tuesday"
                },
                new SelectListItem()
                {
                    Value = "Wednesday",Text = "Wednesday"
                },
                new SelectListItem()
                {
                    Value = "Thursday",Text = "Thursday"
                },
                new SelectListItem()
                {
                    Value = "Friday",Text = "Friday"
                },new SelectListItem()
                {
                    Value = "Saturday",Text = "Saturday"
                }
            };
            return days;
        } 
	}
}