using DataAccessLayer.Repository;

namespace WebAppApi48Core.Services
{
    public class AuthService : IAuthService
    {
        public AuthService(IPersonDataAccess personDataAccess)
        {
            dataAccess = personDataAccess;
        }

        private IPersonDataAccess dataAccess;
        



        public string CreateToken(long personCode, out string UserID, out string Token)
        {           

            if (personCode == PersonDataAccess.INVALID_PERSON_CODE)
            {
                UserID = string.Empty;
                Token = string.Empty;
                return "";
            }

            var userID = this.dataAccess.GetUserID(personCode);

            var guid = Guid.NewGuid();
            Token = guid.ToString();
            UserID = userID;

            dataAccess.AddToken(personCode, Token);
            return "";
        }

        public uint VerifyCredentials(string userID, string password)
        {          
            if (!string.IsNullOrEmpty(userID) && !string.IsNullOrEmpty(password))
            {
                var personCode = dataAccess.GetPersonID(userID, password);
                if(personCode != PersonDataAccess.INVALID_PERSON_CODE && dataAccess.IsAccountLocked(personCode))
                {
                    return PersonDataAccess.INVALID_PERSON_CODE;
                }

                if (dataAccess.IsInvalidPassword(userID, password))
                {
                    personCode = dataAccess.GetPersonID(userID);
                    dataAccess.IncrementInvalidLoginAttempts(personCode);
                    var loginAttemptsCount = dataAccess.GetInvalidLoginAttempts(personCode);
                    if (loginAttemptsCount >= 5)
                    {
                        // Lock the account
                        dataAccess.LockAccount(personCode);
                    }
                }
                else
                {
                    return personCode;
                }

               
            }

            return PersonDataAccess.INVALID_PERSON_CODE;
        }


        public uint CheckToken(string token)
        {
            return dataAccess.CheckToken(token);
        }

        public uint GetPersonCode(HttpContext context)
        {
            return uint.Parse(context.User.Claims.FirstOrDefault(x => x.Type == BasicAuthenticationHandler.PERSON_CODE_CLAIM).Value);
        }
    }
}