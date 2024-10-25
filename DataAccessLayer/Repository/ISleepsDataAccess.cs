using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ISleepsDataAccess
    {      

        IEnumerable<Sleeps> GetSleeps(long personID);

        long UpdateSleeps(long personID, Sleeps t);

        long CreateSleeps(long personID, Sleeps t);

        long DeleteSleeps(long personID, Sleeps t);

    }
}