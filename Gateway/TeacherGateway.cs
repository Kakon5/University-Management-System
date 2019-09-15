using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class TeacherGateway : Gateway
    {
        public int SaveTeacher(Teacher aTeacher)
        {
            Query =
                "INSERT INTO Teacher VALUES(@name, @address, @email, @contactNo, @designationId, @departmentId, @creditToBeTaken, @remainingCredit)";

            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("name", aTeacher.Name);
            Command.Parameters.AddWithValue("address", aTeacher.Address);
            Command.Parameters.AddWithValue("email", aTeacher.Email);
            Command.Parameters.AddWithValue("contactNo", aTeacher.ContactNo);
            Command.Parameters.AddWithValue("designationId", aTeacher.DesignationId);
            Command.Parameters.AddWithValue("departmentId", aTeacher.DepartmentId);
            Command.Parameters.AddWithValue("creditToBeTaken", aTeacher.CreditToBeTaken);
            Command.Parameters.AddWithValue("remainingCredit", aTeacher.CreditToBeTaken);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsEmailExists(string email)
        {
            Query = "SELECT *FROM Teacher WHERE Email = @email";

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

        public List<Teacher> GetTeachersByDepartment(int departmentId)
        {
            Query = "SELECT *FROM Teacher WHERE DepartmentId = " + departmentId;

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Teacher> teachers = new List<Teacher>();
            while (Reader.Read())
            {
                Teacher aTeacher = new Teacher
                {
                    Name = Reader["Name"].ToString(),
                    Id = (int)Reader["Id"]
                };
                teachers.Add(aTeacher);
            }
            Reader.Close();
            Connection.Close();
            return teachers;
        }

        public Teacher GetTeacherInformation(int teacherId)
        {
            Query = "SELECT *FROM Teacher WHERE Id = " + teacherId;

            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Teacher teacher = new Teacher();
            while (Reader.Read())
            {
                teacher.CreditToBeTaken = Convert.ToDouble(Reader["CreditToBeTaken"]);
                teacher.RemainingCredit = Convert.ToDouble(Reader["RemainingCredit"]);

            }
            Reader.Close();
            Connection.Close();
            return teacher;
        }

        public void UpdateTeachersRemainingCredit(Teacher aTeacher)
        {
            Query = "Update Teacher SET RemainingCredit = " + aTeacher.RemainingCredit + "WHERE Id = " + aTeacher.Id;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Command.ExecuteNonQuery();
            Connection.Close();
        }
    }
}