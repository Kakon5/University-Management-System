using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class CourseManager
    {
        CourseGateway aCourseGateway = new CourseGateway();

        public string Save(Course course)
        {
            if (aCourseGateway.IsCodeExits(course.Code))
            {
                return "Course code already exists!";
            }
            if (aCourseGateway.IsNameExits(course.Name))
            {
                return "Course name already exists!";
            }
            int rowAffected = aCourseGateway.Save(course);
            if (rowAffected > 0)
            {
                return "Course is successfully saved!";
            }
            return "Course couldn't be saved!";
        }

        public List<Course> GetallCourses()
        {
            return aCourseGateway.GetallCourses();
        }

        public List<Course> GetCoursesByDepartmentId(int departmentId)
        {
            return aCourseGateway.GetCoursesByDepartmentId(departmentId);
        }

        public Course GetCourseInformation(int courseId)
        {
            return aCourseGateway.GetCourseInformation(courseId);
        }

        public List<Course> GetCoursesWithSemesterByDepartmentId(int departmentId)
        {
            return aCourseGateway.GetCoursesWithSemesterByDepartmentId(departmentId);
        }
    }
}