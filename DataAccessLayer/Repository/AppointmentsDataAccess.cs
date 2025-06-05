using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class AppointmentsDataAccess : DataAccessBase, IAppointmentsDataAccess
    {

        public AppointmentsDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<Appointments> GetAppointments(long personID)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1)
                {
                    var apps = from n in c.GetTable<Appointments>()
                               where n.PersonID == personID
                               orderby n.AppointmentDate descending
                               select n;
                    return apps.ToList();
                }
                else
                {
                    return new Appointments[0];
                }

            }
        }

        public long InsertAppointment(long personID, Appointments appointment)
        {           
            if(personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    appointment.PersonID = personID;
                    return c.Insert<Appointments>( appointment);
                }
            }
            return -1;
        }

        public long UpdateAppointment(long personID, Appointments appointment)
        {
            if(personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    appointment.PersonID = personID;
                    if( c.GetTable<Appointments>().Where(x => x.Id == appointment.Id && x.PersonID == appointment.Id ).Count( ) == 1)                  
                    {                        
                        return c.Update( appointment);
                    }
                }
            }
            return -1;
        }

        public long DeleteAppointment(long personID, long appointmentID)
        {
            if (personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    var a = c.GetTable<Appointments>().Where(x => x.Id == appointmentID && x.PersonID == personID).FirstOrDefault();
                    {
                        return c.Delete(a);
                    }
                }
            }
            return -1;
        }
    }
}