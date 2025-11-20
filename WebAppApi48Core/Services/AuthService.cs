using DataAccessLayer.Repository;
using Microsoft.Extensions.Primitives;

namespace WebAppApi48Core.Services
{
    public class AuthService : IAuthService
    {
        public AuthService(IPersonDataAccess personDataAccess)
        {
            dataAccess = personDataAccess;
        }

        private IPersonDataAccess dataAccess;
        /// <summary>
        /// Returns the personCode
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <returns>a value greater than -1 if user is valid</returns>
        public long VerifyCredentials(HttpRequest httpRequest)
        {
            long personCode = VerifyToken(httpRequest);
            if( personCode  > -1)
            {
                return personCode;
            }

            var userID = string.Empty;
            if(httpRequest.Headers.TryGetValue(HeadersConstants.UserID, out StringValues userIDValues))
            {
                userID = userIDValues.FirstOrDefault();
            }            

            httpRequest.Headers.TryGetValue(HeadersConstants.Password, out StringValues passwordHeaders  );
            var password = passwordHeaders.FirstOrDefault();

            return this.VerifyCredentials(userID, password);
        }

        public long VerifyReadOnlyCredentials(HttpRequest request)
        {

            var userID = string.Empty;
            if (request.Headers.TryGetValue(HeadersConstants.UserID, out StringValues userIDValues))
            {
                userID = userIDValues.FirstOrDefault();
            }           

            if (!string.IsNullOrEmpty(userID))
                return dataAccess.GetPersonIDForReadOnlyAccess(userID);

            return -1;
        }

        public string CreateToken(HttpRequest request, out string UserID, out string Token)
        {
            var personCode = this.VerifyCredentials(request);

            if (personCode < 0)
            {
                UserID = string.Empty;
                Token = string.Empty;
                return "";
            }

            var userID = string.Empty;
            if (request.Headers.TryGetValue(HeadersConstants.UserID, out StringValues userIDValues))
            {
                userID = userIDValues.FirstOrDefault();
            }

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

        public long VerifyToken(HttpRequest httpRequest)
        {
            if (httpRequest.Headers.TryGetValue(HeadersConstants.AuthToken, out StringValues value))
            {
                var token = value.FirstOrDefault();
                var personID = CheckToken(token);
                return personID;
            }
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