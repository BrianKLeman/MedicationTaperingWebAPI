using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class JobsAtHomeViewsDataAccess : DataAccessBase, IJobsAtHomeViewsDataAccess
    {
        public JobsAtHomeViewsDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<JobsAtHomeSummaryView> GetsJobsAtHomeSummary(long personID)
        {
            using (var c = NewDataConnection())
            {
                if (personID != PersonDataAccess.INVALID_PERSON_CODE)
                {
                    var jobs = from j in c.GetTable<JobsAtHomeSummaryView>()
                               where j.PersonId == personID
                               orderby j.DateCompleted descending
                               select j;
                    return jobs.ToList();
                }
                else
                {
                    return new JobsAtHomeSummaryView[0];
                }

            }
        }
    }
}