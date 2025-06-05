using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class TaskLinksDataAccess : DataAccessBase, ITableTasksLinksDataAccess
    {

        public TaskLinksDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }

        public long Insert(long personID, long[] taskIDs, string table_name, long entity_id)
        {
            var result = -1;
            if(personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    // Filter out task ids with links that already exist.
                    var idsThatAlreadyExist = (from t in c.GetTable<TableTaskLinks>()
                                              where t.EntityID == entity_id && t.TableName.Trim() == table_name.Trim() && t.PersonID == personID
                                              select t.TaskID).ToList();
                    // Insert tasks.
                    foreach (var id in taskIDs.Where( x => idsThatAlreadyExist.Contains(x) == false))
                    {
                        result = c.Insert<TableTaskLinks>(new TableTaskLinks() { PersonID = personID, TaskID = id, EntityID = entity_id, TableName = table_name });
                        
                    }
                }
            }
            return -1;            
        }

        public IEnumerable<TableTaskLinks> Select(long personID, long[] taskIDs, string tableName, long entityID)
        {
            List<TableTaskLinks> result = new List<TableTaskLinks>();
            if (personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    foreach (var id in taskIDs)
                    {
                        result.AddRange(c.GetTable<TableTaskLinks>().
                            Where( x => x.EntityID == entityID && x.PersonID == personID && x.TableName == tableName && x.TaskID == id));

                    }
                }
            }
            return result;
        }

        public IEnumerable<TableTaskLinks> Select(long personID, long[] taskIDs, string tableName)
        {
            List<TableTaskLinks> result = new List<TableTaskLinks>();
            if (personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    foreach (var id in taskIDs)
                    {
                        result.AddRange(c.GetTable<TableTaskLinks>().
                            Where(x => x.PersonID == personID && x.TableName == tableName && x.TaskID == id));

                    }
                }
            }
            return result;
        }
    }
}