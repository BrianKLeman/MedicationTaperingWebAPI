using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IDataAccess
    {
        IEnumerable<Medication> GetMedication(long personID);

        int InsertOlanzapine(long personID, DateTime consumedDate, decimal amountMg);

        int InsertSertraline(long personID, DateTime consumedDate, decimal amountMg);

        int Delete(long personID, int medicationId);

        IEnumerable<Prescription> GetPrescriptions(long personID);

        string GetPassword(string username, string password);

        IEnumerable<Notes> GetNotes(long personID, DateTime fromDate, DateTime toDate);

        long GetPersonID(string username, string password);

        long GetPersonIDForReadOnlyAccess(string username);

        long InsertNote(long personID, DateTime date, string note);

        long DeleteNote(long personID, long noteID);
    }
}