using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using LinqToDB;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class AdhocTablesRowsDataAccess : DataAccessBase, IAdhocTableRowDataAccess
    {       
        public IEnumerable<AdhocTableRow> GetScenes(long beatChartID)
        {           
            using (var c = NewDataConnection())
            {
                    var scenes = from g in c.GetTable<AdhocTableRow>()
                                 where g.AdhocTableID == beatChartID
                                 orderby g.Id descending
                                 select g;
                    return scenes.ToList();                       
            }                
        }


        public long CreateRow(long beatChartID, AdhocTableRow scene)
        {
            using (var c = NewDataConnection())
            {
                return c.InsertWithInt32Identity<AdhocTableRow>(scene);
            }
        }

        public long UpdateRow(long beatChartID, AdhocTableRow scene)
        {
            using (var c = NewDataConnection())
            {
                return c.Update<AdhocTableRow>(scene);
            }
        }

        public long DeleteRow(long beatChartID, long sceneID)
        {
            using (var c = NewDataConnection())
            {
                var details = c.GetTable<AdhocTablesDetail>().Where(x => x.AdhocTableID == beatChartID && x.AdhocTableRowID == sceneID).Delete();
                
                return c.Delete<AdhocTableRow>(new AdhocTableRow() { Id = sceneID, AdhocTableID = beatChartID });
            }
        }
    }
}