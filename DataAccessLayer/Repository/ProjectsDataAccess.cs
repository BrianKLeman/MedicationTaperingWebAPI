using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;
using Org.BouncyCastle.Tls.Crypto.Impl;

namespace DataAccessLayer
{
    public class ProjectsDataAccess : DataAccessBase, IProjectsDataAccess
    {
        public ProjectsDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<Projects> GetProjects(uint personID, bool includePersonal)
        {
            using (var c = NewDataConnection())
            {
                var projects = from p in c.GetTable<Projects>()
                                    where p.PersonId == personID && (includePersonal || p.Personal != 1)
                                    select p;

                return projects.ToList();
            }                
        }

        public void UpdateProject(uint personID, Projects project)
        {
            using (var c = NewDataConnection())
            {
                var projects = from p in c.GetTable<Projects>()
                               where p.PersonId == personID && p.ExtProjectID == project.ExtProjectID
                               select p;
                var pr = projects.FirstOrDefault();
                if (pr != null)
                {
                    pr.Name = project.Name;
                    pr.EndDate = project.EndDate;
                    pr.StartDate = project.StartDate;
                }
                c.Update(pr);
            }
        }


    }
}