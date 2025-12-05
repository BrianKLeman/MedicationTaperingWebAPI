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

        public long Insert(uint personID, uint[] taskIDs, string table_name, uint entity_id)
        {
            var result = -1;
            
            using (var c = NewDataConnection())
            {
                // Filter out task ids with links that already exist.
                var idsThatAlreadyExist = (from t in c.GetTable<TableTaskLinks>()
                                            where t.EntityID == entity_id && t.TableName.Trim() == table_name.Trim() && t.PersonId == personID
                                            select t.TaskID).ToList();
                // Insert tasks.
                foreach (var id in taskIDs.Where( x => idsThatAlreadyExist.Contains(x) == false))
                {
                    result = c.Insert<TableTaskLinks>(new TableTaskLinks() { PersonId = (uint)personID, TaskID = id, EntityID = entity_id, TableName = table_name });                        
                }
            }
            
            return result;            
        }

        public IEnumerable<TableTaskLinks> Select(uint personID, uint[] taskIDs, string tableName, uint entityID)
        {
            List<TableTaskLinks> result = new List<TableTaskLinks>();
           
            using (var c = NewDataConnection())
            {
                foreach (var id in taskIDs)
                {
                    result.AddRange(c.GetTable<TableTaskLinks>().
                        Where( x => x.EntityID == entityID && x.PersonId == personID && x.TableName == tableName && x.TaskID == id));
                }
            }
            
            return result;
        }

        public IEnumerable<TableTaskLinks> Select(uint personID, uint[] taskIDs, string tableName)
        {
            List<TableTaskLinks> result = new List<TableTaskLinks>();
            using (var c = NewDataConnection())
            {
                foreach (var id in taskIDs)
                {
                    result.AddRange(c.GetTable<TableTaskLinks>().
                        Where(x => x.PersonId == personID && x.TableName == tableName && x.TaskID == id));

                }
            }
            return result;
        }
    }
}