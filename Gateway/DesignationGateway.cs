using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class DesignationGateway : Gateway
    {

        public List<Designation> GetAllDesignations()
        {
            Query = "SELECT *FROM Designation";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Designation> designations = new List<Designation>();
            while (Reader.Read())
            {
                Designation aDesignation = new Designation
                {
                    Id = (int) Reader["Id"],
                    Name = Reader["Name"].ToString()
                };
                designations.Add(aDesignation);
            }
            Reader.Close();
            Connection.Close();
            return designations;
        } 
    }
}