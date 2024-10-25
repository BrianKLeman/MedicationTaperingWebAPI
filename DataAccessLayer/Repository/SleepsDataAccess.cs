using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class SleepsDataAccess : DataAccessBase, ISleepsDataAccess
    {

        public IEnumerable<Sleeps> GetSleeps(long personID)
        {
            using (var c = NewDataConnection())
            {
                
                if (personID > -1)
                {
                    var sleeps = from p in c.GetTable<Sleeps>()
                                        where p.PersonID == personID
                                        select p;

                    return sleeps.ToList();
                }
                else
                {
                    return new Sleeps[0];
                }
            }                
        }

        public long UpdateSleeps(long personID, Sleeps s)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1 && s.PersonID == personID)
                {
                    s.PersonID = personID;
                    var result = c.Update(s);

                    return result;
                }
                else
                {
                    return -1;
                }
            }
        }

        public long CreateSleeps(long personID, Sleeps sleeps)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1 && (sleeps.PersonID == 0 || sleeps.PersonID == personID))
                {
                    sleeps.Id = 0; // I think setting the task id to zero will make
                                   // it get an id by default.
                    sleeps.PersonID = personID;
                    var result = c.Insert(sleeps);

                    return result;
                }
                else
                {
                    return -1;
                }
            }
        }

        public long DeleteSleeps(long personID, Sleeps sleep)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1 && (sleep.PersonID == 0 || sleep.PersonID == personID))
                {
                    // Check task with same id belongs to same person
                    var ss = from s in c.GetTable<Sleeps>()
                                where s.PersonID == personID && sleep.Id == s.Id
                                select s;

                    var result = -1;
                    foreach (var s in ss.ToList())
                        result = c.Delete(s);

                    return result;
                }
                else
                {
                    return -1;
                }
            }
        }
    }
}