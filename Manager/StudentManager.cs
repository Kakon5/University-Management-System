using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class StudentManager
    {
        StudentGateway aStudentGateway = new StudentGateway();

        public bool IsEmailExists(string email)
        {
            if (aStudentGateway.IsEmailExists(email))
            {
                return true;
            }
            return false;
        }
        public Student SaveStudent(Student aStudent)
        {
            Student student = GenerateRegistrationNo(aStudent);
            int rowAffected = aStudentGateway.SaveStudent(student);
            if (rowAffected > 0)
            {
                return student;
            }
            student = null;
            return student;
            
        }

        public Student GenerateRegistrationNo(Student student)
        {
            string registrationYear = student.Date.ToString("yyyy");
            List<int> studentCodes = aStudentGateway.GetStudentRegistrationNoInformation(registrationYear,
                student.DepartmentId);
            int maxStudentCode = 0;
            foreach (int code in studentCodes)
            {
                if (code > maxStudentCode)
                {
                    maxStudentCode = code;
                }
            }
            maxStudentCode += 1;
            if (maxStudentCode < 10)
            {
                student.Code = "00" + maxStudentCode;
            }
            else if (maxStudentCode >= 10 && maxStudentCode < 100)
            {
                student.Code = "0" + maxStudentCode;
            }
            else
            {
                student.Code = maxStudentCode.ToString();
            }
            student.RegistrationNo = student.DepartmentCode + "-" + registrationYear + "-" + student.Code;

            return student;
        }

        public List<Student> GetAllStudents()
        {
            return aStudentGateway.GetAllStudents();
        }

        public Student GetStudentInformationByStudentId(int studentId)
        {
            return aStudentGateway.GetStudentInformationByStudentId(studentId);
        }
    }
}