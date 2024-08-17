using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ITableNotesLinksDataAccess
    {
        long Insert(long personID, long[] noteIDs, string table_name, long entity_id);    
        
    }
}