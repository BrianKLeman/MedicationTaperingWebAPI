using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IGroupsDataAccess
    {
        IEnumerable<Groups> GetGroups(long personID);       
    }
}