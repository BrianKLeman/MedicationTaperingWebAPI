using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ISubTasksDataAccess
    {
        IEnumerable<SubTasks> GetSubTasks(uint personID, uint[] taskIDs);


        long UpdateSubTask(uint personID, SubTasks t);

        long CreateSubTask(uint personID, SubTasks t);

        long DeleteSubTask(uint personID, uint id);
    }
}