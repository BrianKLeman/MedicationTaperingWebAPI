using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class SubTasksDataAccess : ISubTasksDataAccess
    {

        private AppDataConnection dataConnection;
        public SubTasksDataAccess(AppDataConnection dataConnection)
            : base()
        {
            this.dataConnection = dataConnection;
        }
        public IEnumerable<SubTasks> GetSubTasks(uint personID, uint[] taskIDs)
        {
            var subTasks = from n in dataConnection.GetTable<SubTasks>()
                           where n.PersonId == personID && taskIDs.Contains(n.TaskID)
                           orderby n.Id ascending
                    select n;
            return subTasks.ToList();
                       
        }        

        public long UpdateSubTask(uint personID, SubTasks t)
        {           
            t.PersonId = (uint)personID;
            var result = dataConnection.Update(t);
                    
            return result;
        }

        public long CreateSubTask(uint personID, SubTasks t)
        {           
            t.Id = 0; 
            t.PersonId = (uint)personID;
            return (uint)dataConnection.InsertWithIdentity(t);
        }

        public long DeleteTask(uint personID, uint taskID)
        {
            // Check task with same id belongs to same person
            var tasks = from task in dataConnection.GetTable<SubTasks>()
                        where task.PersonId == personID && taskID == task.Id
                        select task;

            return dataConnection.Delete(tasks);
        }

        public long DeleteSubTasks(uint personID, uint[] subTaskIDs)
        {
            // Check task with same id belongs to same person
            var tasks = from task in dataConnection.GetTable<SubTasks>()
                        where task.PersonId == personID && subTaskIDs.Contains(task.Id)
                        select task;

            return dataConnection.Delete(tasks);
        }
    }
}