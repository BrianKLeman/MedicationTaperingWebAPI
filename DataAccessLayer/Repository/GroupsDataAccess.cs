using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using LinqToDB;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer
{
    public class GroupsDataAccess : DataAccessBase, IGroupsDataAccess
    {
        public GroupsDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<Groups> GetGroups(long personID)
        {           
            using (var c = NewDataConnection())
            {
                if(personID > -1)
                {
                    var groups = from g in c.GetTable<Groups>()
                                 where g.PersonId == personID
                                 orderby g.Id descending
                                 select g;
                    return groups.ToList();
                }
                else
                {
                    return new Groups[0];
                }                
            }                
        }       
    }
}