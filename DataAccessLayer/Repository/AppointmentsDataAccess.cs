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
                var apps = from n in c.GetTable<Appointments>()
                            where n.PersonId == personID
                            orderby n.AppointmentDate descending
                            select n;
                return apps.ToList();
            }
        }

        public long InsertAppointment(long personID, Appointments appointment)
        {    
            using (var c = NewDataConnection())
            {
                appointment.PersonId = (uint)personID;
                return c.Insert<Appointments>( appointment);
            }
        }

        public long UpdateAppointment(long personID, Appointments appointment)
        {
            using (var c = NewDataConnection())
            {
                appointment.PersonId = (uint)personID;
                if( c.GetTable<Appointments>().Where(x => x.Id == appointment.Id && x.PersonId == appointment.Id ).Count( ) == 1)                  
                {                        
                    return c.Update( appointment);
                }
                else
                {
                    return -1;
                }
            }
        }

        public long DeleteAppointment(long personID, long appointmentID)
        {
            using (var c = NewDataConnection())
            {
                var a = c.GetTable<Appointments>().Where(x => x.Id == appointmentID && x.PersonId == personID).FirstOrDefault();
                {
                    return c.Delete(a);
                }
            }
        }
    }
}