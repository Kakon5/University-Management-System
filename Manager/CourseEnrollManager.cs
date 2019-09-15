using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class CourseEnrollManager
    {
        CourseEnrollGateway aCourseEnrollGateway = new CourseEnrollGateway();

        public string EnrollCourse(CourseEnroll aCourseEnroll)
        {
            if (aCourseEnrollGateway.IsCourseEnrolledByStudent(aCourseEnroll.StudentId, aCourseEnroll.CourseId))
            {
                return "The student already enrolled to this course!";
            }

            int rowAffected = aCourseEnrollGateway.EnrollCourse(aCourseEnroll);
            if (rowAffected > 0)
            {
                return "Course enrollment successful!";
            }
            return "Course enrollment failed!";
        }

        public List<CourseEnroll> GetEnrolledCoursesByStudentId(int studentId)
        {
            return aCourseEnrollGateway.GetEnrolledCoursesByStudentId(studentId);
        }

        public string UpdateStudentGrade(CourseEnroll aCourseEnroll)
        {
            int rowAffected = aCourseEnrollGateway.UpdateStudentGrade(aCourseEnroll);
            if (rowAffected>0)
            {
                return "Course grade is updated!";
            }
            return "Course grade couldn't be updated!";
        }
    }
}