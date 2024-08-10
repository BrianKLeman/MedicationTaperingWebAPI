using DataAccessLayer;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Web.Http;
using WebAppApi48.Attributes;
using WebAppApi48.Services;
using Resolver = System.Web.Mvc.DependencyResolver;

namespace WebAppApi48.Controllers
{
    [RoutePrefix("Api/Projects")]
    [Route("{action=Get}")]
    public class ProjectsController : ApiController
    {
        public ProjectsController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(IProjectsDataAccess)) as IProjectsDataAccess;
        }

        private IAuthService authService;
        private IProjectsDataAccess dataAccess;
        public IEnumerable<Projects> Get()
        {
            var personID = this.authService.VerifyCredentials(Request);
            return dataAccess.GetProjects(personID);
        }
        
    }
}