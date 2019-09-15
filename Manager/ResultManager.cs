using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ResultManager
    {
        ResultGateway aResultGateway = new ResultGateway();
        public List<Result> GetResultsByStudentId(int id)
        {
            return aResultGateway.GetResultsByStudentId(id);
        }
    }
}