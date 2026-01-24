using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class TasksDataAccess : DataAccessBase, ITasksDataAccess
    {
        public TasksDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<Tasks> GetTasks(uint personID, bool includePersonal)
        {
            int personal = includePersonal ? 1 : 0;
            using (var c = NewDataConnection())
            {
                var notes = from n in c.GetTable<Tasks>()
                        where n.PersonId == personID && (personal == 1 || n.Personal == personal)
                            orderby n.CreatedDate descending
                        select n;
                return notes.ToList();
            }                
        }
        
        public Tasks GetTasksByExtID(object personCode, uint workItemId)
        {
            using (var c = NewDataConnection())
            {
                var task = from n in c.GetTable<Tasks>()
                           where n.PersonId == (uint)personCode && n.ExternalID == workItemId
                           select n;
                return task.FirstOrDefault();
            }
        }
        public IEnumerable<Tasks> GetTasks(uint personID, string tableName, long entityID, bool includePersonal)
        {
            int personal = includePersonal ? 1 : 0;
            using (var c = NewDataConnection())
            {
                var tasks = from n in c.GetTable<Tasks>()
                            where n.PersonId == personID && (personal == 1 || n.Personal == personal)
                            join l in c.GetTable<TableTaskLinks>() on n.Id equals l.TaskID
                            where ( l.PersonId == personID && l.TableName == tableName && l.EntityID == entityID)
                                
                            orderby n.CreatedDate descending
                            select n;
                return tasks.ToList().GroupBy(x => x.Id).Select( x => x.First()).ToList();
            }
        }

        public long UpdateTask(uint personID, Tasks t)
        {
            using (var c = NewDataConnection())
            {
                t.PersonId = (uint)personID;
                var result = c.Update(t);
                    
                return result;
            }
        }

        public long CreateTask(uint personID, Tasks t)
        {
            using (var c = NewDataConnection())
            {
                t.Id = 0; // I think setting the task id to zero will make
                            // it get an id by default.
                t.PersonId = (uint)personID;
                var result = c.Insert(t);

                var tasks = from n in c.GetTable<Tasks>()
                where n.TaskName == t.TaskName && n.PersonId == personID
                select n;
                return tasks.Max<Tasks>( (x) => x.Id);                
            }
        }

        public long DeleteTask(uint personID, uint taskID)
        {
            using (var c = NewDataConnection())
            {
                // Check task with same id belongs to same person
                var tasks = from task in c.GetTable<Tasks>()
                            where task.PersonId == personID && taskID == task.Id
                            select task;

                var result = -1;
                foreach (var task in tasks.ToList())
                    result = c.Delete(task);

                return result;
            }
        }

        public long DeleteTaskByExternalID(uint personID, uint workitemID)
        {
            using (var c = NewDataConnection())
            {
                // Check task with same id belongs to same person
                var tasks = from task in c.GetTable<Tasks>()
                            where task.PersonId == personID && workitemID == task.ExternalID
                            select task;

                var result = -1;
                foreach (var task in tasks.ToList())
                    result = c.Delete(task);

                return result;
            }
        }
    }
}