using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class JobsAtHomeDataAccess : DataAccessBase, IJobsAtHomeDataAccess
    {
        public JobsAtHomeDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<JobsAtHome> GetJobsAtHome(long personID)
        {
            using (var c = NewDataConnection())
            {
                var apps = from n in c.GetTable<JobsAtHome>()
                            where n.PersonId == personID
                            orderby n.CreatedDate descending
                            select n;
                return apps.ToList();   
            }
        }
    }
}