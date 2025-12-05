using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using LinqToDB;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class AdhocTablesDataAccess : DataAccessBase, IAdhocTablesDataAccess
    {
        public AdhocTablesDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<AdhocTable> GetAdhocTables(long personID)
        {           
            using (var c = NewDataConnection())
            {                
                var beats = from g in c.GetTable<AdhocTable>()
                                where g.PersonId == personID
                                orderby g.Id descending
                                select g;
                return beats.ToList();                             
            }                
        }

        public long CreateNewTable(long personID, long projectID, string name)
        {
            using (var c = NewDataConnection())
            {
                return c.InsertWithInt32Identity<AdhocTable>(new AdhocTable() { Name = name, PersonId = (uint)personID, ProjectID = projectID });                
            }
        }


        public long DeleteTable(long personID, long tableID)
        {
            using (var c = NewDataConnection())
            {
               
                // Check table belongs to same person
                if(c.GetTable<AdhocTable>().Where(x => x.Id == tableID && x.PersonId == personID).Count() > 0)
                {
                    c.GetTable<AdhocTablesDetail>().Where(x => x.AdhocTableID == tableID).Delete();
                    c.GetTable<AdhocTableRow>().Where(x => x.AdhocTableID == tableID).Delete();
                    c.GetTable<AdhocTableColumn>().Where(x => x.AdhocTableID == tableID).Delete();
                    c.GetTable<AdhocTable>().Where(x => x.Id == tableID && x.PersonId == personID).Delete();
                    return 0;
                }
                else
                {
                    return -1;
                }               
            }
        }
    }
}