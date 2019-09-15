using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class TeacherManager
    {
        TeacherGateway aTeacherGateway = new TeacherGateway();

        public string SaveTeacher(Teacher aTeacher)
        {
            if (aTeacherGateway.IsEmailExists(aTeacher.Email))
            {
                return "Email already Exists!";
            }
            int rowAffected = aTeacherGateway.SaveTeacher(aTeacher);
            if (rowAffected > 0)
            {
                return "Teacher information is sucessfully saved!";
            }
            return "Teacher information couldn't be saved!";
        }

        public List<Teacher> GetTeachersByDepartment(int departmentId)
        {
            return aTeacherGateway.GetTeachersByDepartment(departmentId);
        }

        public Teacher GetTeacherInformation(int teacherId)
        {
            return aTeacherGateway.GetTeacherInformation(teacherId);
        }

        public void UpdateTeachersRemainingCredit(Teacher aTeacher)
        {
            aTeacherGateway.UpdateTeachersRemainingCredit(aTeacher);
        }
    }
}