using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class JobsAtHomeLogDataAccess : DataAccessBase, IJobsAtHomeLogDataAccess
    {
        public JobsAtHomeLogDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<JobsAtHomeLog> GetJobsAtHomeLogs(long personID)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1)
                {
                    var apps = from n in c.GetTable<JobsAtHomeLog>()
                               where n.PersonId == personID
                               orderby n.DateCompleted descending
                               select n;
                    return apps.ToList();
                }
                else
                {
                    return new JobsAtHomeLog[0];
                }

            }
        }

        public long AddActivity(long personID, long jobAtHomeID, DateTime date)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1)
                {
                    var activity = new JobsAtHomeLog() { CreatedDate = DateTime.Now, DateCompleted = date, CreatedUser = "BKL", JobID = jobAtHomeID, PersonId = (uint)personID };
                    return c.Insert(activity);                    
                }

                return -1;

            }
        }
    }
}