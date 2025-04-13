using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using LinqToDB;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class AdhocTablesColumnsDataAccess : DataAccessBase, IAdhocColumnDataAccess
    {       
        public IEnumerable<AdhocTableColumn> GetColumns(long beatChartID)
        {           
            using (var c = NewDataConnection())
            {
                    var beats = from g in c.GetTable<AdhocTableColumn>()
                                 where g.AdhocTableID == beatChartID
                                 orderby g.Id descending
                                 select g;
                    return beats.ToList();                       
            }                
        }


        public long CreateColumn(long beatchartID, string sectionName)
        {
            using (var c = NewDataConnection())
            {
                var maxOrder = c.GetTable<AdhocTableColumn>().Where(x => x.AdhocTableID == beatchartID).Max(x => x.Order);
                return c.InsertWithInt32Identity<AdhocTableColumn>(new AdhocTableColumn() { AdhocTableID = beatchartID, Name = sectionName, Order = maxOrder + 1 });
            }
        }

        public long DeleteColumn(long beatchartID, long sectionID)
        {
            using (var c = NewDataConnection())
            {
                // Delete details
                c.GetTable<AdhocTablesDetail>().Where(x => x.AdhocTableID == beatchartID && x.AdhocTableColumnID == sectionID).Delete();
                // Delete section
                return c.GetTable<AdhocTableColumn>().Where( x=> x.AdhocTableID == beatchartID && x.Id == sectionID).Delete();
            }
        }
    }
}