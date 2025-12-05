using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ISleepsDataAccess
    {      

        IEnumerable<Sleeps> GetSleeps(uint personID);

        long UpdateSleeps(uint personID, Sleeps t);

        long CreateSleeps(uint personID, Sleeps t);

        long DeleteSleeps(uint personID, Sleeps t);

    }
}