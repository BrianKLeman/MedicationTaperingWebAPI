using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IMedicationDataAccess
    {
        IEnumerable<Medication> GetMedication(long personID);

        int InsertOlanzapine(long personID, DateTime consumedDate, decimal amountMg);

        int InsertSertraline(long personID, DateTime consumedDate, decimal amountMg);

        int Delete(long personID, int medicationId);
        
    }
}