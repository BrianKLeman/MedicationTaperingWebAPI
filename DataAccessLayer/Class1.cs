using DataAccessLayer.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using LinqToDB.DataProvider.MySql;
using System.Linq;
using LinqToDB;
namespace DataAccessLayer
{
    public static class ConnectionTester
    {

        static ConnectionTester()
        {
            OpenConnection();
        }

        private static LinqToDB.Data.DataConnection _connection;
        

        public static IEnumerable<Medication> GetMedication()
        {
            CheckConnection();
            var meds = from c in _connection.GetTable<Medication>()
                       select c;

            return meds;
        }

        public static int InsertOlanzapine(DateTime consumedDate, decimal amountMg)
        {
            CheckConnection();
            return _connection.Insert<Medication>(new Medication() { CreatedDate = DateTime.Now, CreatedUser = "BKL", DateTimeConsumed = consumedDate, PrescriptionId = 3, DoseTakenMG = amountMg, PersonID = 1 });
        }

        public static int InsertSertraline(DateTime consumedDate, decimal amountMg)
        {
            CheckConnection();
            return _connection.Insert<Medication>(new Medication() { CreatedDate = DateTime.Now, CreatedUser = "BKL", DateTimeConsumed = consumedDate, PrescriptionId = 4, DoseTakenMG = amountMg, PersonID = 1 });
        }

        public static int Delete(int medicationId)
        {
            CheckConnection();
            return _connection.Delete<Medication>(new Medication { MedicationID = medicationId });
        }

        private static void CheckConnection()
        {
            _connection.Connection.Close();
            OpenConnection();

        }

        private static void OpenConnection()
        {
            var cBuilder = new MySqlConnectionStringBuilder();
            cBuilder.Server = DatalayerConfig.GetHost(); 
            cBuilder.Port = DatalayerConfig.GetPort();
            cBuilder.UserID = DatalayerConfig.GetUserName();
            cBuilder.Password = DatalayerConfig.GetPassword();
            cBuilder.Database = DatalayerConfig.GetDataBaseName();

            _connection = MySqlTools.CreateDataConnection(cBuilder.ConnectionString);
        }


        public static IEnumerable<Prescription> GetPrescriptions()
        {
            CheckConnection();
            var prescriptions = from c in _connection.GetTable<Prescription>()
                                select c;

            return prescriptions;
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
            CheckConnection();
            var person = from p in _connection.GetTable<People>()
                   where (p.PersonID == personId)
                   select p;
            return person.FirstOrDefault()?.Password ?? string.Empty;
        }
    }
}