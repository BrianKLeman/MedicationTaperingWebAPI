using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ITasksDataAccess
    {
        IEnumerable<Tasks> GetTasks(uint personID, bool includePersonal);

        IEnumerable<Tasks> GetTasks(uint personID, string tableName, long entityID, bool includePersonal);

        long UpdateTask(uint personID, Tasks t);

        long CreateTask(uint personID, Tasks t);

        long DeleteTask(uint personID, uint taskID);
        Tasks GetTasksByExtID(object personCode, uint workItemId);

        public long DeleteTaskByExternalID(uint personID, uint workitemID);
    }
}