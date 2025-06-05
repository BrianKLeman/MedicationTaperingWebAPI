using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class PhenomenaDataAccess : DataAccessBase, IPhenomenaDataAccess
    {
        public PhenomenaDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<Phenomena> GetPhenomena(long personID)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1)
                {
                    var p = from n in c.GetTable<Phenomena>()
                               where n.PersonID == personID
                               select n;
                    return p.ToList();
                }
                else
                {
                    return new Phenomena[0];
                }

            }
        }
    }
}