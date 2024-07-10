using DataAccessLayer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using LinqToDB.DataProvider.MySql;
using System.Linq;
using LinqToDB;
using LinqToDB.Data;

namespace DataAccessLayer
{
    public class MedicationDataAccess : IMedicationDataAccess
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

        public int InsertOlanzapine(long personID, DateTime consumedDate, decimal amountMg)
        {
            if (personID > -1)
            {
                using (var db = NewDataConnection())
                {
                    return db.Insert<Medication>(new Medication() { CreatedDate = DateTime.Now, CreatedUser = "BKL", DateTimeConsumed = consumedDate, PrescriptionId = 3, DoseTakenMG = amountMg, PersonID = personID });
                }
            }

            return -1;
        }

        public int InsertSertraline(long personID, DateTime consumedDate, decimal amountMg)
        {
            if (personID > -1)
            {
                using (var db = NewDataConnection())
                {
                    return db.Insert<Medication>(new Medication() { CreatedDate = DateTime.Now, CreatedUser = "BKL", DateTimeConsumed = consumedDate, PrescriptionId = 4, DoseTakenMG = amountMg, PersonID = personID });
                }
            }

            return -1;
                
        }

        public int Delete(long personID, int medicationId)
        {
            if (personID > -1)
            {

                using (var db = NewDataConnection())
                    return db.Delete<Medication>(new Medication { MedicationID = medicationId, PersonID = personID });
            }
            else
            {
                return -1;
            }
        }

       

        private DataConnection NewDataConnection()
        {
            var cBuilder = new MySqlConnectionStringBuilder();
            cBuilder.Server = DatalayerConfig.GetHost(); 
            cBuilder.Port = DatalayerConfig.GetPort();
            cBuilder.UserID = DatalayerConfig.GetUserName();
            cBuilder.Password = DatalayerConfig.GetPassword();
            cBuilder.Database = DatalayerConfig.GetDataBaseName();

            return MySqlTools.CreateDataConnection(cBuilder.ConnectionString);
        }

        
        
    }
}