using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IAdhocTablesDetailsDataAccess
    {
        IEnumerable<AdhocTablesDetail> GetDetails(long beatchartID);

        long CreateDetail(long beatchartID, AdhocTablesDetail detail);

        long UpdateDetail(long beatchartID, AdhocTablesDetail detail);
    }
}