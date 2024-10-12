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
       

        public long Insert(long personID, long[] taskIDs, string table_name, long entity_id)
        {
            var result = -1;
            if(personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    foreach (var id in taskIDs)
                    {
                        result = c.Insert<TableTaskLinks>(new TableTaskLinks() { PersonID = personID, TaskID = id, EntityID = entity_id, TableName = table_name });
                        
                    }
                }
            }
            return -1;            
        }

       
    }
}