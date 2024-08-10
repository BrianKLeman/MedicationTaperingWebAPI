using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class ProjectsDataAccess : DataAccessBase, IProjectsDataAccess
    {     

        public IEnumerable<Projects> GetProjects(long personID)
        {
            using (var c = NewDataConnection())
            {
                
                if (personID > -1)
                {
                    var projects = from p in c.GetTable<Projects>()
                                        where p.PersonID == personID
                                        select p;

                    return projects.ToList();
                }
                else
                {
                    return new Projects[0];
                }
            }                
        }    

        
    }
}