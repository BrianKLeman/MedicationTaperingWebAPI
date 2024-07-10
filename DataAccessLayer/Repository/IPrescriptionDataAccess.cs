using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IPrescriptionDataAccess
    {      

        IEnumerable<Prescription> GetPrescriptions(long personID);
        
    }
}