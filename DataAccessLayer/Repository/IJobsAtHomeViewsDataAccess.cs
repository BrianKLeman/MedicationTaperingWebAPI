using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public interface IJobsAtHomeViewsDataAccess 
    {
        IEnumerable<JobsAtHomeSummaryView> GetsJobsAtHomeSummary(long personID);
    }
}