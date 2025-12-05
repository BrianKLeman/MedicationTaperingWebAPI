using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class SleepsDataAccess : DataAccessBase, ISleepsDataAccess
    {
        public SleepsDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<Sleeps> GetSleeps(uint personID)
        {
            using (var c = NewDataConnection())
            {
                var sleeps = from p in c.GetTable<Sleeps>()
                                    where p.PersonId == personID
                                    select p;

                return sleeps.ToList();
            }                
        }

        public long UpdateSleeps(uint personID, Sleeps s)
        {
            using (var c = NewDataConnection())
            {
                s.PersonId = (uint)personID;
                var result = c.Update(s);

                return result;               
            }
        }

        public long CreateSleeps(uint personID, Sleeps sleeps)
        {
            using (var c = NewDataConnection())
            {
                sleeps.Id = 0; // I think setting the id to zero will make
                                // it get an id by default.
                sleeps.PersonId = (uint)personID;
                var result = c.Insert(sleeps);

                return result;
            }
        }

        public long DeleteSleeps(uint personID, Sleeps sleep)
        {
            using (var c = NewDataConnection())
            {
                // Check task with same id belongs to same person
                var ss = from s in c.GetTable<Sleeps>()
                            where s.PersonId == personID && sleep.Id == s.Id
                            select s;

                var result = -1;
                foreach (var s in ss.ToList())
                    result = c.Delete(s);

                return result;
            }
        }
    }
}