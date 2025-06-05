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
        public IEnumerable<Prescription> GetPrescriptions(long personID)
        {
            using (var c = NewDataConnection())
            {
                
                if (personID > -1)
                {
                    var prescriptions = from p in c.GetTable<Prescription>()
                                        where p.PersonID == personID
                                        select p;

                    return prescriptions.ToList();
                }
                else
                {
                    return new Prescription[0];
                }
            }                
        }    

        
    }
}