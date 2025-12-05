using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

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

        
    }
}