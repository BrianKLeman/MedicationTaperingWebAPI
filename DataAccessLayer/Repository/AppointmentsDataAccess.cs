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
    }
}