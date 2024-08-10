using DataAccessLayer;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Web.Http;
using WebAppApi48.Attributes;
using WebAppApi48.Services;
using Resolver = System.Web.Mvc.DependencyResolver;

namespace WebAppApi48.Controllers
{
    [RoutePrefix("Api/Sleeps")]
    [Route("{action=Get}")]
    public class SleepsController : ApiController
    {
        public SleepsController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(ISleepsDataAccess)) as ISleepsDataAccess;
        }

        private IAuthService authService;
        private ISleepsDataAccess dataAccess;
        public IEnumerable<Sleeps> Get()
        {
            var personID = this.authService.VerifyCredentials(Request);
            return dataAccess.GetSleeps(personID);
        }
        
    }
}