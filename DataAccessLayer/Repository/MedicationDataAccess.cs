using DataAccessLayer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using LinqToDB.DataProvider.MySql;
using System.Linq;
using LinqToDB;
using LinqToDB.Data;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class MedicationDataAccess : DataAccessBase, IMedicationDataAccess
    {
        public MedicationDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<Medication> GetMedication(long personID)
        {           
            using (var c = NewDataConnection())
            {
                var meds = from m in c.GetTable<Medication>()
                            select m;

                return meds.ToList();
            }
        }

        public int Delete(long personID, int medicationId)
        {
            using (var db = NewDataConnection())
                return db.Delete<Medication>(new Medication { Id = (uint)medicationId, PersonId = (uint)personID });
        }   
        public int InsertMedication(long personID, DateTime consumedDate, long prescriptionID, decimal amountMg)
        {
            using (var db = NewDataConnection())
            {
                return db.Insert(new Medication() { CreatedDate = DateTime.Now, CreatedUser = "BKL", DateTimeConsumed = consumedDate, PrescriptionId = (uint)prescriptionID, DoseTakenMG = amountMg, PersonId = (uint)personID });
            }
        }
    }
}