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

            if (personCode < 0)
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

        public long VerifyCredentials(string userID, string password)
        {          
            if (!string.IsNullOrEmpty(userID) && !string.IsNullOrEmpty(password))
                return dataAccess.GetPersonID(userID, password);

            return -1;
        }


        public long CheckToken(string token)
        {
            return dataAccess.CheckToken(token);
        }

        public long GetPersonCode(HttpContext context)
        {
            return long.Parse(context.User.Claims.FirstOrDefault(x => x.Type == BasicAuthenticationHandler.PERSON_CODE_CLAIM).Value);
        }
    }
}