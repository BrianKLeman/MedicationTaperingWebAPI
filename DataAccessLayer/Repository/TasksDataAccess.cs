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
        public IEnumerable<Tasks> GetTasks(long personID, bool includePersonal)
        {
            int personal = includePersonal ? 1 : 0;
            using (var c = NewDataConnection())
            {
                if(personID > -1)
                {
                    var notes = from n in c.GetTable<Tasks>()
                            where n.PersonId == personID && (personal == 1 || n.Personal == personal)
                                orderby n.CreatedDate descending
                            select n;
                    return notes.ToList();
                }
                else
                {
                    return new Tasks[0];
                }
                
            }                
        }

        public IEnumerable<Tasks> GetTasks(long personID, string tableName, long entityID, bool includePersonal)
        {
            int personal = includePersonal ? 1 : 0;
            using (var c = NewDataConnection())
            {
                if (personID > -1)
                {
                    var tasks = from n in c.GetTable<Tasks>()
                                where n.PersonId == personID && (personal == 1 || n.Personal == personal)
                                join l in c.GetTable<TableTaskLinks>() on n.Id equals l.TaskID
                                where ( l.PersonId == personID && l.TableName == tableName && l.EntityID == entityID)
                                
                                orderby n.CreatedDate descending
                                select n;
                    return tasks.ToList().GroupBy(x => x.Id).Select( x => x.First()).ToList();
                }
                else
                {
                    return new Tasks[0];
                }

            }
        }

        public long UpdateTask(long personID, Tasks t)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1 && t.PersonId == personID)
                {
                    t.PersonId = (uint)personID;
                    var result = c.Update(t);
                    
                    return result;
                }
                else
                {
                    return -1;
                }
            }
        }

        public long CreateTask(long personID, Tasks t)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1 && (t.PersonId == 0 || t.PersonId == personID))
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
                else
                {
                    return -1;
                }
            }
        }

        public long DeleteTask(long personID, Tasks t)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1 && (t.PersonId == 0 || t.PersonId == personID))
                {
                    // Check task with same id belongs to same person
                    var tasks = from task in c.GetTable<Tasks>()
                                where task.PersonId == personID && t.Id == task.Id
                                select task;

                    var result = -1;
                    foreach (var task in tasks.ToList())
                        result = c.Delete(task);

                    return result;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}