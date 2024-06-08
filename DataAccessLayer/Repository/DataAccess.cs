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
        public static IEnumerable<Medication> GetMedication(long personID)
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

        public static int InsertOlanzapine(long personID, DateTime consumedDate, decimal amountMg)
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

        public static int InsertSertraline(long personID, DateTime consumedDate, decimal amountMg)
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

        public static int Delete(long personID, int medicationId)
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


        public static IEnumerable<Prescription> GetPrescriptions(long personID)
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

        public static IEnumerable<Notes> GetNotes(long personID, DateTime fromDate, DateTime toDate)
        {
            using (var c = NewDataConnection())
            {
                if(personID > -1)
                {
                    var notes = from n in c.GetTable<Notes>()
                            where n.PersonID == personID && fromDate < n.RecordedDate && toDate > n.RecordedDate
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

        public static long GetPersonIDForReadOnlyAccess(string username)
        {
            using (var c = NewDataConnection())
            {
                var a = from p in c.GetTable<People>()
                        where p.ReadOnlyAnon != null && p.ReadOnlyAnon.Trim() != "" && p.ReadOnlyAnon == username
                        select p;
                return a.FirstOrDefault()?.PersonID ?? -1;
            }
        }

        public static long InsertNote(long personID, DateTime date, string note)
        {
            if(personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    return c.Insert<Notes>(new Notes() { PersonID = personID, RecordedDate = date, Text = note, UpdatedUser = "BKL" });
                }
            }
            return -1;            
        }

        public static long DeleteNote(long personID, long noteID)
        {
            if(personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    return c.Delete<Notes>(new Notes { NoteID = noteID, PersonID = personID });
                }
            }

            return -1;
        }
    }
}