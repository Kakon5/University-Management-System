using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class CourseAssignManager
    {
        CourseAssignGateway aCourseAssignGateway = new CourseAssignGateway();
        CourseManager aCourseManager = new CourseManager();
        TeacherManager aTeacherManager = new TeacherManager();
        public string AssignCourse(CourseAssign aCourseAssign)
        {
            if (aCourseAssignGateway.IsCourseAssigned(aCourseAssign.CourseId))
            {
                return "The course is already assigned!";
            }
            int rowAffected = aCourseAssignGateway.AssignCourse(aCourseAssign);

            if (rowAffected > 0)
            {
                Course aCourse = aCourseManager.GetCourseInformation(aCourseAssign.CourseId);
                Teacher aTeacher = aTeacherManager.GetTeacherInformation(aCourseAssign.TeacherId);
                aTeacher.RemainingCredit -= aCourse.Credit;
                aTeacher.Id = aCourseAssign.TeacherId;
                aTeacherManager.UpdateTeachersRemainingCredit(aTeacher);
                return "Course is successfully assigned!";
            }
            return "Course assign operation is failed!";
        }

        public string UnassignAllCourses()
        {
            int rowAffected = aCourseAssignGateway.UnassignAllCourses();
            if (rowAffected > 0)
            {
                return "All courses are successfully unassigned!";
            }
            return "All courses are already unassigned!";
        }
    }
}