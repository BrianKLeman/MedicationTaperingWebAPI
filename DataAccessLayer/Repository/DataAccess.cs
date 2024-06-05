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
    public static class DataAccess
    {     
        public static IEnumerable<Medication> GetMedication(string username, string password)
        {
            var pID = GetPersonID(username, password);

            if (pID > -1)
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

        public static int InsertOlanzapine(string userName, string password, DateTime consumedDate, decimal amountMg)
        {
            var pID = GetPersonID(userName, password);

            if (pID > -1)
            {
                using (var db = NewDataConnection())
                {
                    return db.Insert<Medication>(new Medication() { CreatedDate = DateTime.Now, CreatedUser = "BKL", DateTimeConsumed = consumedDate, PrescriptionId = 3, DoseTakenMG = amountMg, PersonID = pID });
                }
            }

            return -1;
        }

        public static int InsertSertraline(string userName, string password, DateTime consumedDate, decimal amountMg)
        {
            var pID = GetPersonID(userName, password);

            if (pID > -1)
            {
                using (var db = NewDataConnection())
                {
                    return db.Insert<Medication>(new Medication() { CreatedDate = DateTime.Now, CreatedUser = "BKL", DateTimeConsumed = consumedDate, PrescriptionId = 4, DoseTakenMG = amountMg, pID = 1 });
                }
            }

            return -1;
                
        }

        public static int Delete(string userName, string password, int medicationId)
        {
            var pID = GetPersonID(userName, password);

            if (pID > -1)
            {

                using (var db = NewDataConnection())
                    return db.Delete<Medication>(new Medication { MedicationID = medicationId, PersonID = pID });
            }
            else
            {
                return -1;
            }
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


        public static IEnumerable<Prescription> GetPrescriptions(string username, string password)
        {
            using (var c = NewDataConnection())
            {
                var pID = GetPersonID(username, password);

                if (pID > -1)
                {
                    var prescriptions = from p in c.GetTable<Prescription>()
                                        where p.PersonID == pID
                                        select p;

                    return prescriptions.ToList();
                }
                else
                {
                    return new Prescription[0];
                }
            }                
        }

        public class DayPrescription
        {
            DateTime? Day;
            public decimal doseMg { get; set; } = 0;
            public int prescriptionID { get; set; } = 0;
            public string prescriptionName = "None";
        }

        public static string GetPassword(string username, string password)
        {
            using(var c = NewDataConnection())
            {
                var pID = GetPersonID(username, password);

                if (pID > -1)
                {
                    var person = from p in c.GetTable<People>()
                       where (p.PersonID == pID)
                       select p;
                    var people = person.ToList().FirstOrDefault();
                    return people?.Password ?? string.Empty;
                }

                return string.Empty;
            }
        }

        public static IEnumerable<Notes> GetNotes(string username, string password, DateTime fromDate, DateTime toDate)
        {
            using (var c = NewDataConnection())
            {
                var pID = GetPersonID(username, password);

                if(pID > -1)
                {
                    var notes = from n in c.GetTable<Notes>()
                            where n.PersonID == pID && fromDate < n.RecordedDate && toDate > n.RecordedDate
                            select n;
                    return notes.ToList();
                }
                else
                {
                    return new Notes[0];
                }
                
            }                
        }

        public static long GetPersonID(string username, string password)
        {
            using (var c = NewDataConnection())
            {
                var a = from p in c.GetTable<People>()
                            where p.Password == password && p.PeopleAnon == username
                            select p;
                return a.FirstOrDefault()?.PersonID ?? -1;
            }
        }
    }
}