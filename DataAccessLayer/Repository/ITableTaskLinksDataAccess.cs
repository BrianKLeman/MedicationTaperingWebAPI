using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ITableTasksLinksDataAccess
    {
        long Insert(long personID, long[] taskIDs, string table_name, long entity_id);
        IEnumerable<TableTaskLinks> Select(long personID, long[] taskIDs, string tableName, long entityID);
        IEnumerable<TableTaskLinks> Select(long personID, long[] taskIDs, string tableName);
    }
}