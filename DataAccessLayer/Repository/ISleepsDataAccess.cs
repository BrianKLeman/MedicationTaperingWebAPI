using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface ISleepsDataAccess
    {      

        IEnumerable<Sleeps> GetSleeps(long personID);
        
    }
}