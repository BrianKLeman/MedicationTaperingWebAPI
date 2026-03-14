using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class TaskLinksDataAccess : ITableTasksLinksDataAccess
    {
        private AppDataConnection dataConnection;
        public TaskLinksDataAccess(AppDataConnection dataConnection)
            : base() 
        {
            this.dataConnection = dataConnection;
        }

        public long Insert(uint personID, uint[] taskIDs, string table_name, uint entity_id)
        {
            var result = -1;
            
            // Filter out task ids with links that already exist.
            var idsThatAlreadyExist = (from t in dataConnection.GetTable<TableTaskLinks>()
                                        where t.EntityID == entity_id && t.TableName.Trim() == table_name.Trim() && t.PersonId == personID
                                        select t.TaskID).ToList();
            // Insert tasks.
            foreach (var id in taskIDs.Where( x => idsThatAlreadyExist.Contains(x) == false))
            {
                result = dataConnection.Insert<TableTaskLinks>(new TableTaskLinks() { PersonId = (uint)personID, TaskID = id, EntityID = entity_id, TableName = table_name });                        
            }

            return result;            
        }

        public IEnumerable<TableTaskLinks> Select(uint personID, uint[] taskIDs, string tableName, uint entityID)
        {            
            return dataConnection.GetTable<TableTaskLinks>().
                    Where( x => x.EntityID == entityID && x.PersonId == personID && x.TableName == tableName && taskIDs.Contains(x.TaskID));
        }

        public IEnumerable<TableTaskLinks> Select(uint personID, uint[] taskIDs, string[] tableNames)
        {
            return dataConnection.GetTable<TableTaskLinks>()
            .Where(x => x.PersonId == personID && tableNames.Contains(x.TableName) && taskIDs.Contains(x.TaskID));
        }

        public IEnumerable<TableTaskLinks> Select(uint personID, uint[] taskIDs, string tableName)
        {
            return dataConnection.GetTable<TableTaskLinks>()
            .Where(x => x.PersonId == personID && x.TableName == tableName && taskIDs.Contains(x.TaskID));
        }

        public IEnumerable<TableTaskLinks> Select(uint personID, uint[] taskIDs)
        {
            return dataConnection.GetTable<TableTaskLinks>().Where(x => x.PersonId == personID && taskIDs.Contains(x.TaskID)).ToList();            
        }

        public long Delete(uint personID, uint[] taskIDs, string tableName)
        {
           return dataConnection.GetTable<TableTaskLinks>().
                        Where(x => x.PersonId == personID && x.TableName == tableName && taskIDs.Contains(x.TaskID)).Delete();
        }

        public long Delete(uint personID, uint[] taskIDs, string tableName, uint entityID)
        {
            return dataConnection.GetTable<TableTaskLinks>().
                        Where(x => x.PersonId == personID && x.TableName == tableName && taskIDs.Contains(x.TaskID) && x.EntityID == entityID).
                        Delete();
        }
    }
}