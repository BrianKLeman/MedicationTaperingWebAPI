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
        public IEnumerable<Tasks> GetTasks(long personID)
        {
            using (var c = NewDataConnection())
            {
                if(personID > -1)
                {
                    var notes = from n in c.GetTable<Tasks>()
                            where n.PersonID == personID 
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

        public IEnumerable<Tasks> GetTasks(long personID, string tableName, long entityID)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1)
                {
                    var tasks = from n in c.GetTable<Tasks>()
                                where n.PersonID == personID
                                join l in c.GetTable<TableTaskLinks>() on n.Id equals l.TaskID
                                where ( l.PersonID == personID && l.TableName == tableName && l.EntityID == entityID)
                                orderby n.CreatedDate descending
                                select n;
                    return tasks.ToList();
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
                if (personID > -1 && t.PersonID == personID)
                {
                    t.PersonID = personID;
                    var result = c.Update(t);
                    
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