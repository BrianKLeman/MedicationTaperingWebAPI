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
            List<TableTaskLinks> result = new List<TableTaskLinks>();
           
                foreach (var id in taskIDs)
                {
                    result.AddRange(dataConnection.GetTable<TableTaskLinks>().
                        Where( x => x.EntityID == entityID && x.PersonId == personID && x.TableName == tableName && x.TaskID == id));
                }
            
            return result;
        }

        public IEnumerable<TableTaskLinks> Select(uint personID, uint[] taskIDs, string[] tableNames)
        {
            List<TableTaskLinks> result = new List<TableTaskLinks>();
            var ids = taskIDs.ToList();


            return dataConnection.GetTable<TableTaskLinks>()
            .Where(x => x.PersonId == personID && tableNames.Contains(x.TableName))
                .Where(x => ids.Contains(x.TaskID));
            
        }

        public IEnumerable<TableTaskLinks> Select(uint personID, uint[] taskIDs, string tableName)
        {
            List<TableTaskLinks> result = new List<TableTaskLinks>();
            var ids = taskIDs.ToList();
            
                
                    dataConnection.GetTable<TableTaskLinks>()
                    .Where(x => x.PersonId == personID && x.TableName == tableName)
                        .Where( x => ids.Contains( x.TaskID ));
            return result;
        }

        public IEnumerable<TableTaskLinks> Select(uint personID, uint[] taskIDs)
        {
            List<TableTaskLinks> result = new List<TableTaskLinks>();
            var ids = taskIDs.ToList();
            return dataConnection.GetTable<TableTaskLinks>().Where(x => x.PersonId == personID && ids.Contains(x.TaskID)).ToList();            
        }

        public long Delete(uint personID, uint[] taskIDs, string tableName)
        {
            long result = 0;
           
                foreach (var id in taskIDs)
                {
                    result += dataConnection.GetTable<TableTaskLinks>().
                        Where(x => x.PersonId == personID && x.TableName == tableName && x.TaskID == id).
                        Delete();
                }
            
            return result;
        }

        public long Delete(uint personID, uint[] taskIDs, string tableName, uint entityID)
        {
            long result = 0;
                foreach (var id in taskIDs)
                {
                    result += dataConnection.GetTable<TableTaskLinks>().
                        Where(x => x.PersonId == personID && x.TableName == tableName && x.TaskID == id && x.EntityID == entityID).
                        Delete();
                }
            return result;
        }
    }
}