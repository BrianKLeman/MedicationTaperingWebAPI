using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IProjectsDataAccess
    {      
        IEnumerable<Projects> GetProjects(uint personID, bool includePersonal);
    }
}