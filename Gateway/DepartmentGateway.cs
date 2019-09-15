using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class DepartmentGateway : Gateway
    {

        public int Save (Department department)
        {
            Query = "INSERT INTO Department VALUES(@code,@name)";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Code", department.Code);
            Command.Parameters.AddWithValue("name", department.Name);

            Connection.Open();

            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public bool IsCodeExits(string Code)
        {
            
            Query = "SELECT * FROM Department WHERE Code=  @code";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("code", Code);
            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            bool hasRow = false;
            if (reader.HasRows)
            {
                hasRow = true;
            }
            reader.Close();
            Connection.Close();
            return hasRow;
        }
        public bool IsNameExits(string Name)
        {
            
            Query = "SELECT * FROM Department WHERE Name= @name";
            Command = new SqlCommand(Query, Connection);

            Command.Parameters.Clear();

            Command.Parameters.AddWithValue("name", Name);

            Connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            bool hasRow = false;
            if (reader.HasRows)
            {
                hasRow = true;
            }
            reader.Close();
            Connection.Close();
            return hasRow;
        }

        public List<Department> GetAllDepartments()
        {
            Query = "SELECT *FROM Department";

            Command = new SqlCommand(Query,Connection);

            Connection.Open();
            List<Department> departments = new List<Department>();
            
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Department aDepartment = new Department
                {
                    Id = (int) Reader["Id"],
                    Code = Reader["Code"].ToString(),
                    Name = Reader["Name"].ToString()
                };
                departments.Add(aDepartment);
            }
            Reader.Close();
            Connection.Close();
            return departments;
        }

        public string FindDepartmentCode(int id)
        {

            Query = "SELECT Code FROM Department WHERE Id = " + id;
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            string code = "";
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                code = Reader["Code"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return code;
        }
        public string FindDepartmentName(int id)
        {

            Query = "SELECT Name FROM Department WHERE Id = " + id;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            string name = "";
            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                name = Reader["Name"].ToString();
            }
            Reader.Close();
            Connection.Close();
            return name;
        }
    }
}