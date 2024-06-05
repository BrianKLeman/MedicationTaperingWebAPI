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
    public static class ConnectionTester
    {     
        public static IEnumerable<Medication> GetMedication()
        {
            using (var c = NewDataConnection())
            {
                var meds = from m in c.GetTable<Medication>()
                           select m;

                return meds.ToList();
            }                
        }

        public static int InsertOlanzapine(DateTime consumedDate, decimal amountMg)
        {
            using (var db = NewDataConnection())
            {
                return db.Insert<Medication>(new Medication() { CreatedDate = DateTime.Now, CreatedUser = "BKL", DateTimeConsumed = consumedDate, PrescriptionId = 3, DoseTakenMG = amountMg, PersonID = 1 });
            }
        }

        public static int InsertSertraline(DateTime consumedDate, decimal amountMg)
        {
            using (var db = NewDataConnection())
            {
                return db.Insert<Medication>(new Medication() { CreatedDate = DateTime.Now, CreatedUser = "BKL", DateTimeConsumed = consumedDate, PrescriptionId = 4, DoseTakenMG = amountMg, PersonID = 1 });
            }
                
        }

        public static int Delete(int medicationId)
        {
            using( var db = NewDataConnection())
                return  db.Delete<Medication>(new Medication { MedicationID = medicationId });
        }

       

        private static DataConnection NewDataConnection()
        {
            var cBuilder = new MySqlConnectionStringBuilder();
            cBuilder.Server = DatalayerConfig.GetHost(); 
            cBuilder.Port = DatalayerConfig.GetPort();
            cBuilder.UserID = DatalayerConfig.GetUserName();
            cBuilder.Password = DatalayerConfig.GetPassword();
            cBuilder.Database = DatalayerConfig.GetDataBaseName();

            return MySqlTools.CreateDataConnection(cBuilder.ConnectionString);
        }


        public static IEnumerable<Prescription> GetPrescriptions()
        {
            using (var c = NewDataConnection())
            {
                var prescriptions = from p in c.GetTable<Prescription>()
                                    select p;

                return prescriptions.ToList();
            }                
        }

        public class DayPrescription
        {
            DateTime? Day;
            public decimal doseMg { get; set; } = 0;
            public int prescriptionID { get; set; } = 0;
            public string prescriptionName = "None";
        }

        public static string GetPassword(long personId)
        {
            using(var c = NewDataConnection())
            {
                var person = from p in c.GetTable<People>()
                   where (p.PersonID == personId)
                   select p;
                var people = person.ToList().FirstOrDefault();
                return people?.Password ?? string.Empty;
            }
        }

        public static IEnumerable<Notes> GetNotes(long personID, DateTime fromDate, DateTime toDate)
        {
            using (var c = NewDataConnection())
            {
                var notes = from n in c.GetTable<Notes>()
                            where n.PersonID == personID && fromDate < n.RecordedDate && toDate > n.RecordedDate
                            select n;
                return notes.ToList();
            }                
        }
    }
}