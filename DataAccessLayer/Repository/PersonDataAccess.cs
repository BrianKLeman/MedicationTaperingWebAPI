using DataAccessLayer.Models;
using LinqToDB;
using System;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class PersonDataAccess : DataAccessBase, IPersonDataAccess
    {
        public long AddToken(long personID, string token)
        {
            if (personID > 0)
            {
                using (var c = NewDataConnection())
                {
                     return c.Insert<AuthTokens>(new AuthTokens() { AuthToken = token, PersonID = personID, TokenDate = new DateTime() });
                }
            }

            return -1;
        }

        public long CheckToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return -1;

            using (var c = NewDataConnection())
            {
                var p = from t in c.GetTable<AuthTokens>()
                        where t.AuthToken == token
                        select t;

                return p.FirstOrDefault()?.PersonID ?? -1;
            }
        }

        public string GetPassword(string username, string password)
        {
            using (var c = NewDataConnection())
            {
                var pID = GetPersonID(username, password);

                if (pID > -1)
                {
                    var person = from p in c.GetTable<People>()
                                 where (p.PersonID == pID)
                                 select p;
                    var people = person.ToList().FirstOrDefault();
                    return people?.Password ?? string.Empty;
                }

                return string.Empty;
            }
        }

        public long GetPersonID(string username, string password)
        {
            using (var c = NewDataConnection())
            {
                var a = from p in c.GetTable<People>()
                        where p.Password == password && p.PeopleAnon == username
                        select p;
                return a.FirstOrDefault()?.PersonID ?? -1;
            }
        }

        public long GetPersonIDForReadOnlyAccess(string username)
        {
            using (var c = NewDataConnection())
            {
                var a = from p in c.GetTable<People>()
                        where p.ReadOnlyAnon != null && p.ReadOnlyAnon.Trim() != "" && p.ReadOnlyAnon == username
                        select p;
                return a.FirstOrDefault()?.PersonID ?? -1;
            }
        }
    }
}
