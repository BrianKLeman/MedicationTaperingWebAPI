using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IAdhocTableRowDataAccess
    {
        IEnumerable<AdhocTableRow> GetScenes(long beatchartID);
        long CreateRow(long beatchartID, AdhocTableRow scene);
        long UpdateRow(long beatchartID, AdhocTableRow scene);
        long DeleteRow(long beatChartID, long sceneID);
    }
}