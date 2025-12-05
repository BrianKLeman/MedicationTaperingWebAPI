using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class PrescriptionDataAccess : DataAccessBase, IPrescriptionDataAccess
    {
        public PrescriptionDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<Prescription> GetPrescriptions(uint personID)
        {
            using (var c = NewDataConnection())
            {
                var prescriptions = from p in c.GetTable<Prescription>()
                                    where p.PersonId == personID
                                    select p;

                return prescriptions.ToList();
            }                
        }  
    }
}