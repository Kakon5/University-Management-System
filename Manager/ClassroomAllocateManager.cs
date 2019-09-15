using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementSystem.Gateway;
using UniversityManagementSystem.Models;

namespace UniversityManagementSystem.Manager
{
    public class ClassroomAllocateManager
    {
        ClassroomAllocateGateway aClassroomAllocateGateway = new ClassroomAllocateGateway();

        public string AllocateClassroom(ClassroomAllocate aClassroomAllocate)
        {
            DateTime startTime = DateTime.Parse(aClassroomAllocate.StartTime);
            DateTime endTime = DateTime.Parse(aClassroomAllocate.EndTime);

            if (startTime.TimeOfDay > endTime.TimeOfDay)
            {
                return "Time range is not valid!";
            }
            if (aClassroomAllocateGateway.IsPossibleToAllocate(aClassroomAllocate))
            {
                int rowAffected = aClassroomAllocateGateway.AllocateClassroom(aClassroomAllocate);
                if (rowAffected > 0)
                {
                    return "Classroom is Successfully Allocated!";
                }
            }
            return "Allocation is not possible!";
        }

        public string UnallocateAllClassrooms()
        {
            int rowAffected = aClassroomAllocateGateway.UnallocateAllClassrooms();
            if (rowAffected > 0)
            {
                return "All classrooms are successfully unallocated!";
            }
            return "All classrooms are already unallocted!";
        }

    }
}