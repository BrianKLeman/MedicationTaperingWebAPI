using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IAdhocColumnDataAccess
    {
        IEnumerable<AdhocTableColumn> GetColumns(long beatchartID);

        long CreateColumn(long beatchartID, string sectionName);
        long DeleteColumn(long beatchartID, long sectionID);
    }
}