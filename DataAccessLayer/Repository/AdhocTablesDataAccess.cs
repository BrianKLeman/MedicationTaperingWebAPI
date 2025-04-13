using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using LinqToDB;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class AdhocTablesDataAccess : DataAccessBase, IAdhocTablesDataAccess
    {       
        public IEnumerable<AdhocTable> GetAdhocTables(long personID)
        {           
            using (var c = NewDataConnection())
            {
                if(personID > -1)
                {
                    var beats = from g in c.GetTable<AdhocTable>()
                                 where g.PersonID == personID
                                 orderby g.Id descending
                                 select g;
                    return beats.ToList();
                }
                else
                {
                    return new AdhocTable[0];
                }                
            }                
        }

        public long CreateNewTable(long personID, long projectID, string name)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1)
                {
                    return c.InsertWithInt32Identity<AdhocTable>(new AdhocTable() { Name = name, PersonID = personID, ProjectID = projectID });
                }
                else
                {
                    return -1;
                }
            }
        }


        public long DeleteTable(long personID, long tableID)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1)
                {
                    // Check table belongs to same person
                    if(c.GetTable<AdhocTable>().Where(x => x.Id == tableID && x.PersonID == personID).Count() > 0)
                    {
                        c.GetTable<AdhocTablesDetail>().Where(x => x.AdhocTableID == tableID).Delete();
                        c.GetTable<AdhocTableRow>().Where(x => x.AdhocTableID == tableID).Delete();
                        c.GetTable<AdhocTableColumn>().Where(x => x.AdhocTableID == tableID).Delete();
                        c.GetTable<AdhocTable>().Where(x => x.Id == tableID && x.PersonID == personID).Delete();
                        return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}