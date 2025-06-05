using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using LinqToDB;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class AdhocTablesDetailsDataAccess : DataAccessBase, IAdhocTablesDetailsDataAccess
    {
        public AdhocTablesDetailsDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<AdhocTablesDetail> GetDetails(long beatChartID)
        {           
            using (var c = NewDataConnection())
            {
                    var details = from g in c.GetTable<AdhocTablesDetail>()
                                 where g.AdhocTableID == beatChartID
                                 orderby g.Id descending
                                 select g;
                    return details.ToList();                       
            }                
        }

        public long CreateDetail(long beatChartID, AdhocTablesDetail detail)
        {
            using (var c = NewDataConnection())
            {
                return c.InsertWithInt32Identity<AdhocTablesDetail>(detail);
            }
        }

        public long UpdateDetail(long beatChartID, AdhocTablesDetail detail)
        {
            using (var c = NewDataConnection())
            {
                return c.Update<AdhocTablesDetail>(detail);
            }
        }
    }
}