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
                if (personID > -1)
                {
                    var aims = from n in c.GetTable<LearningAims>()
                               where n.PersonId == personID
                               select n;
                    return aims.ToList();
                }
                else
                {
                    return new LearningAims[0];
                }

            }
        }
    }
}