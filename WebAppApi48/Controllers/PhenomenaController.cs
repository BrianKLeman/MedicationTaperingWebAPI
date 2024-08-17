using DataAccessLayer;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Web.Http;
using WebAppApi48.Attributes;
using WebAppApi48.Services;
using Resolver = System.Web.Mvc.DependencyResolver;

namespace WebAppApi48.Controllers
{
    [RoutePrefix("Api/Phenomena")]
    [Route("{action=Get}")]
    public class PhenomenaController : ApiController
    {
        public PhenomenaController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(IPhenomenaDataAccess)) as IPhenomenaDataAccess;
        }

        private IAuthService authService;
        private IPhenomenaDataAccess dataAccess;
        public IEnumerable<Phenomena> Get()
        {
            var personID = this.authService.VerifyCredentials(Request);
            return dataAccess.GetPhenomena(personID);
        }
        
    }
}