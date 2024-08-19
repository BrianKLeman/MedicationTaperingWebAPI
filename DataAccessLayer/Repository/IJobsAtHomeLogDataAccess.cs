using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IJobsAtHomeLogDataAccess
    {
        IEnumerable<JobsAtHomeLog> GetJobsAtHomeLogs(long personID);

        long AddActivity(long personID, long jobAtHomeID, DateTime date);
    }
}