using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ITableTasksLinksDataAccess
    {
        long Insert(uint personID, uint[] taskIDs, string table_name, uint entity_id);
        IEnumerable<TableTaskLinks> Select(uint personID, uint[] taskIDs, string tableName, uint entityID);
        IEnumerable<TableTaskLinks> Select(uint personID, uint[] taskIDs, string tableName);
    }
}