using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Manager;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class StudentGateway : Gateway
    {
        
        public int SaveStudent(Student aStudent)
        {
            Query =
                "INSERT INTO Student VALUES(@name, @email, @contactNo, @date, @address, @code, @registrationNo, @departmentId)";

            Command = new SqlCommand(Query,Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", aStudent.Name);
            Command.Parameters.AddWithValue("email", aStudent.Email);
            Command.Parameters.AddWithValue("contactNo", aStudent.ContactNo);
            Command.Parameters.AddWithValue("date", aStudent.Date);
            Command.Parameters.AddWithValue("address", aStudent.Address);
            Command.Parameters.AddWithValue("code", aStudent.Code);
            Command.Parameters.AddWithValue("registrationNo", aStudent.RegistrationNo);
            Command.Parameters.AddWithValue("departmentId", aStudent.DepartmentId);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<int> GetStudentRegistrationNoInformation(string date, int deptId)
        {
            Query = "SELECT *FROM RegistrationNoInfromation WHERE Date = '"+ date +"' AND DeptId = " + deptId;

            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<int> studentCodes = new List<int>();

            while (Reader.Read())
            {
                int aStudentCode = Convert.ToInt32(Reader["StudentCode"]);
                studentCodes.Add(aStudentCode);
            }
            Reader.Close();
            Connection.Close();
            return studentCodes;

        }

        public bool IsEmailExists(string email)
        {
            Query = "SELECT *FROM Student WHERE Email = @email";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            
            Command.Parameters.AddWithValue("email", email);
           
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRows = false;
            if (Reader.HasRows)
            {
                hasRows = true;
            }
            Connection.Close();
            return hasRows;
        }
        public Student GetStudentInformationByStudentId(int studentId)
        {
            Query = "SELECT *FROM GetStudentsWithDepartmentName WHERE StudentId = " + studentId;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Student aStudent = new Student();
            while (Reader.Read())
            {
                aStudent.Id = (int) Reader["StudentId"];
                aStudent.Name = Reader["Name"].ToString();
                aStudent.RegistrationNo = Reader["RegistrationNo"].ToString();
                aStudent.Email = Reader["Email"].ToString();
                aStudent.DepartmentId = (int) Reader["DepartmentId"];
                aStudent.DepartmentName = Reader["DeptName"].ToString();
                aStudent.Address = Reader["Address"].ToString();

            }
            Reader.Close();
            Connection.Close();
            return aStudent;
        }

        public List<Student> GetAllStudents()
        {
            Query = "SELECT *FROM Student";
            Command  = new SqlCommand(Query,Connection);
            Connection.Open();

            Reader = Command.ExecuteReader();
            List<Student> students = new List<Student>();
            while (Reader.Read())
            {
                Student aStudent = new Student
                {
                    Id = (int) Reader["Id"],
                    
                    RegistrationNo = Reader["RegistrationNo"].ToString()
                };
                students.Add(aStudent);
            }
            Reader.Close();
            Connection.Close();
            return students;
        } 
    }
}