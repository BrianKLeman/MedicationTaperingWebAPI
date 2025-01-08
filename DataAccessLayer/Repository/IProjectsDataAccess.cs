using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IProjectsDataAccess
    {      

        IEnumerable<Projects> GetProjects(long personID, bool includePersonal);
        
    }
}