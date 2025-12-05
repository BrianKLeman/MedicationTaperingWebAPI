
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IPrescriptionDataAccess
    {      

        IEnumerable<DataAccessLayer.Models.Prescription> GetPrescriptions(uint personID);
        
    }
}