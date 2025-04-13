using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IAdhocTablesDataAccess
    {
        IEnumerable<AdhocTable> GetAdhocTables(long personID);

        long CreateNewTable(long personID, long projectID, string name);


        long DeleteTable(long personID, long tableID);
    }
}