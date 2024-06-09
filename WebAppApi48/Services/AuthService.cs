using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

using Resolver = System.Web.Mvc.DependencyResolver;
namespace WebAppApi48.Services
{
    public class AuthService : IAuthService
    {
        public AuthService()
        {
            dataAccess = (IDataAccess)Resolver.Current.GetService(typeof(IDataAccess));
        }

        private IDataAccess dataAccess;
        /// <summary>
        /// Returns the personCode
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <returns>a value greater than -1 if user is valid</returns>
        public long VerifyCredentials(HttpRequestMessage httpRequest)
        {
            var userID = string.Empty;
            if(httpRequest.Headers.Contains(HeadersConstants.UserID))
            {
                userID = httpRequest.Headers.GetValues(HeadersConstants.UserID).FirstOrDefault();
            }            

            httpRequest.Headers.TryGetValues(HeadersConstants.Password, out IEnumerable<string> passwordHeaders  );
            var password = passwordHeaders?.FirstOrDefault();

            if(!string.IsNullOrEmpty(userID) && !string.IsNullOrEmpty(password))
                return dataAccess.GetPersonID(userID, password);
            
            return -1;
        }

        public long VerifyReadOnlyCredentials(HttpRequestMessage request)
        {
            var userID = string.Empty;
            if (request.Headers.Contains(HeadersConstants.UserID))
            {
                userID = request.Headers.GetValues(HeadersConstants.UserID).FirstOrDefault();
            }           

            if (!string.IsNullOrEmpty(userID))
                return dataAccess.GetPersonIDForReadOnlyAccess(userID);

            return -1;
        }
    }
}