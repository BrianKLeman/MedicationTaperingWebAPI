using DataAccessLayer;
using DataAccessLayer.Repository;
using System;
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
            dataAccess = (IPersonDataAccess)Resolver.Current.GetService(typeof(IPersonDataAccess));
        }

        private IPersonDataAccess dataAccess;
        /// <summary>
        /// Returns the personCode
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="password"></param>
        /// <returns>a value greater than -1 if user is valid</returns>
        public long VerifyCredentials(HttpRequestMessage httpRequest)
        {
            if(httpRequest.Headers.Contains(HeadersConstants.AuthToken))
            {
                var token = httpRequest.Headers.GetValues(HeadersConstants.AuthToken).FirstOrDefault();
                var personID = dataAccess.CheckToken(token);
                if (personID > 0)
                    return personID;
            }

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

        public string CreateToken(HttpRequestMessage request, out string UserID, out string Token)
        {
            var personCode = this.VerifyCredentials(request);

            if (personCode < 0)
            {
                UserID = string.Empty;
                Token = string.Empty;
                return "";
            }

            var userID = string.Empty;
            if (request.Headers.Contains(HeadersConstants.UserID))
            {
                userID = request.Headers.GetValues(HeadersConstants.UserID).FirstOrDefault();
            }

            var guid = Guid.NewGuid();
            Token = guid.ToString();
            UserID = userID;

            dataAccess.AddToken(personCode, Token);
            return "";
        }
        
    }
}