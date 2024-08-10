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

        
    }
}