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
        public IEnumerable<Medication> GetMedication(long personID)
        {
            if (personID > -1)
            {

                using (var c = NewDataConnection())
                {
                    var meds = from m in c.GetTable<Medication>()
                               select m;

                    return meds.ToList();
                }
            }

            return new Medication[0];
        }

        public int Delete(long personID, int medicationId)
        {
            if (personID > -1)
            {

                using (var db = NewDataConnection())
                    return db.Delete<Medication>(new Medication { Id = medicationId, PersonID = personID });
            }
            else
            {
                return -1;
            }
        }   

       

        public int InsertMedication(long personID, DateTime consumedDate, long prescriptionID, decimal amountMg)
        {
            if (personID > -1)
            {
                using (var db = NewDataConnection())
                {
                    return db.Insert(new Medication() { CreatedDate = DateTime.Now, CreatedUser = "BKL", DateTimeConsumed = consumedDate, PrescriptionId = prescriptionID, DoseTakenMG = amountMg, PersonID = personID });
                }
            }

            return -1;
        }
    }
}