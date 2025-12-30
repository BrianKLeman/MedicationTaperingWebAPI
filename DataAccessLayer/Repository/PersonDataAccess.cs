using DataAccessLayer.Models;
using LinqToDB;
using System;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class PersonDataAccess : DataAccessBase, IPersonDataAccess
    {
        public static readonly uint INVALID_PERSON_CODE = 0;
        public PersonDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public uint AddToken(long personID, string token)
        {
            if (personID != INVALID_PERSON_CODE)
            {
                using (var c = NewDataConnection())
                {
                     return (uint)c.Insert<AuthTokens>(new AuthTokens() { AuthToken = token, PersonId = (uint)personID, TokenDate = DateTime.Now });
                }
            }

            return INVALID_PERSON_CODE;
        }

        public uint CheckToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
                return INVALID_PERSON_CODE;

            using (var c = NewDataConnection())
            {
                var p = from t in c.GetTable<AuthTokens>()
                        where t.AuthToken == token
                        select t;
                uint id = INVALID_PERSON_CODE;
                if(p.FirstOrDefault() != null)
                {
                    id = p.FirstOrDefault().PersonId;
                }
                return id;
            }
        }

        public string GetPassword(string username, string password)
        {
            using (var c = NewDataConnection())
            {
                var pID = GetPersonID(username, password);

                if (pID != INVALID_PERSON_CODE)
                {
                    var person = from p in c.GetTable<People>()
                                 where (p.PersonId == pID)
                                 select p;
                    var people = person.ToList().FirstOrDefault();
                    return people?.Password ?? string.Empty;
                }

                return string.Empty;
            }
        }

        public uint GetPersonID(string username, string password)
        {
            using (var c = NewDataConnection())
            {
                var a = from p in c.GetTable<People>()
                        where p.Password == password && p.PeopleAnon == username
                        select p;
                uint id = INVALID_PERSON_CODE;
                if (a?.FirstOrDefault() is People ppl)
                {
                    id = ppl.PersonId;
                }
                return id;
            }
        }

        public uint GetPersonIDForReadOnlyAccess(string username)
        {
            using (var c = NewDataConnection())
            {
                var a = from p in c.GetTable<People>()
                        where p.ReadOnlyAnon != null && p.ReadOnlyAnon.Trim() != "" && p.ReadOnlyAnon == username
                        select p;
                uint id = INVALID_PERSON_CODE;
                if (a?.FirstOrDefault() is People ppl)
                {
                    id = ppl.PersonId;
                }
                return id;
            }
        }

        public string GetUserID(long personCode)
        {
            using (var c = NewDataConnection())
            {
                    var person = from p in c.GetTable<People>()
                                 where (p.PersonId == personCode)
                                 select p;
                    var people = person.ToList().FirstOrDefault();
                    return people?.PeopleAnon ?? string.Empty;   
            }
        }

        public bool IsAccountLocked(long personID)
        {
            using (var c = NewDataConnection())
            {
                var person = from p in c.GetTable<People>()
                             where (p.PersonId == personID)
                             select p;
                var people = person.ToList().FirstOrDefault();
                return people.Locked != 0;
            }
        }

        public bool IsInvalidPassword(string username, string password)
        {
            using (var c = NewDataConnection())
            {
                var person = from p in c.GetTable<People>()
                             where (p.PeopleAnon == username)
                             select p;
                var people = person.ToList().FirstOrDefault();
                if (people != null)
                {
                    return people.Password != password;
                }
                return true;
            }
        }

        public bool LockAccount(long personID)
        {
            using (var c = NewDataConnection())
            {
                var person = from p in c.GetTable<People>()
                             where (p.PersonId == personID)
                             select p;
                var people = person.ToList().FirstOrDefault();
                if (people != null)
                {
                    people.Locked = 1;
                    c.Update(people);
                    return true;
                }
                return false;
            }
        }

        public void IncrementInvalidLoginAttempts(long personID)
        {
            using (var c = NewDataConnection())
            {
                var person = from p in c.GetTable<People>()
                             where (p.PersonId == personID)
                             select p;
                var people = person.ToList().FirstOrDefault();
                if (people != null)
                {
                    people.PasswordIncorrectCount += 1;
                    c.Update(people);
                }
            }
        }

        public int GetInvalidLoginAttempts(long personID)
        {            
            using (var c = NewDataConnection())
            {
                var person = from p in c.GetTable<People>()
                             where (p.PersonId == personID)
                             select p;
                var people = person.ToList().FirstOrDefault();
                if (people != null)
                {
                    return people.PasswordIncorrectCount;
                }
            }

            return 0;
        }

        public uint GetPersonID(string username)
        {
            using (var c = NewDataConnection())
            {
                var a = from p in c.GetTable<People>()
                        where p.PeopleAnon == username
                        select p;
                uint id = INVALID_PERSON_CODE;
                if (a?.FirstOrDefault() is People ppl)
                {
                    id = ppl.PersonId;
                }
                return id;
            }
        }

        public void LockAccount(uint personID)
        {
            using (var c = NewDataConnection())
            {
                var person = from p in c.GetTable<People>()
                             where (p.PersonId == personID)
                             select p;
                var people = person.ToList().FirstOrDefault();
                if (people != null)
                {
                    people.Locked = 1;
                    c.Update(people);
                }
            }
        }
    }
}
