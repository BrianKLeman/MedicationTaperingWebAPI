using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IMedicationDataAccess
    {
        IEnumerable<Medication> GetMedication(long personID);

        int Delete(long personID, int medicationId);

        int InsertMedication(long personID, DateTime consumedDate, long prescriptionID, decimal amountMg);
        
    }
}