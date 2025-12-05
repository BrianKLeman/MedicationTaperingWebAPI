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
        public IEnumerable<Phenomena> GetPhenomena(uint personID)
        {
            using (var c = NewDataConnection())
            {
                var p = from n in c.GetTable<Phenomena>()
                            where n.PersonId == personID
                            select n;
                return p.ToList();               
            }
        }
    }
}