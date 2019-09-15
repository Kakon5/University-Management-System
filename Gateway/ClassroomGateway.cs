using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Gateway
{
    public class ClassroomGateway : Gateway
    {
        public List<Classroom> GetAllClassrooms()
        {
            Query = "SELECT *FROM Classroom";
            Command = new SqlCommand(Query,Connection);

            Connection.Open();
            Reader = Command.ExecuteReader();

            List<Classroom> classrooms = new List<Classroom>();
            while (Reader.Read())
            {
                Classroom aClassroom = new Classroom
                {
                    Id = (int) Reader["Id"],
                    RoomNo = Reader["RoomNo"].ToString()
                };
                classrooms.Add(aClassroom);
            }
            return classrooms;
        } 
    }
}