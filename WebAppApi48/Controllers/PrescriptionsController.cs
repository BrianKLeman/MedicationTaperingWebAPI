using DataAccessLayer;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Web.Http;
using WebAppApi48.Attributes;
using WebAppApi48.Services;
using Resolver = System.Web.Mvc.DependencyResolver;

namespace WebAppApi48.Controllers
{
    [RoutePrefix("Prescriptions")]
    [Route("{action=Get}")]
    public class PrescriptionsController : ApiController
    {
        public PrescriptionsController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
        }

        private IAuthService authService;
        public IEnumerable<Prescription> Get()
        {
            var personID = this.authService.VerifyCredentials(Request);
            return DataAccess.GetPrescriptions(personID);
        }
        
    }
}