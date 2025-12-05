using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class LearningAimsDataAccess : DataAccessBase, ILearningAimsDataAccess
    {
        public LearningAimsDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<LearningAims> GetAims(long personID)
        {
            using (var c = NewDataConnection())
            {
                var aims = from n in c.GetTable<LearningAims>()
                            where n.PersonId == personID
                            select n;
                return aims.ToList();
            }
        }
    }
}