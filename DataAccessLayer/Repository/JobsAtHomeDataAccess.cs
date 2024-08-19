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
        public IEnumerable<JobsAtHome> GetJobsAtHome(long personID)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1)
                {
                    var apps = from n in c.GetTable<JobsAtHome>()
                               where n.PersonID == personID
                               orderby n.AppointmentDate descending
                               select n;
                    return apps.ToList();
                }
                else
                {
                    return new JobsAtHome[0];
                }

            }
        }
    }
}