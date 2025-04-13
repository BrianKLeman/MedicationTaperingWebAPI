using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IAppointmentsDataAccess
    {
        IEnumerable<Appointments> GetAppointments(long personID);
        long InsertAppointment(long personID, Appointments appointment);
        long UpdateAppointment(long personID, Appointments appointment);

        
        long DeleteAppointment(long personID, long appointmentID);
        
    }
}