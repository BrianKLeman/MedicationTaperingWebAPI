using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using WebAppApi48.Services;

using Resolver = System.Web.Mvc.DependencyResolver;
namespace WebAppApi48.Controllers
{    

    [RoutePrefix("Api/Groups")]
    public class GroupsController : ApiController
    {        
        public GroupsController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(IGroupsDataAccess)) as IGroupsDataAccess;
            
        }

        private IAuthService authService;
        private IGroupsDataAccess dataAccess;
        
        public IHttpActionResult Get()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            return base.Ok(dataAccess.GetGroups(personID));
        }

        [Route("TaskGroups")]
        public IHttpActionResult TaskGroups()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            return base.Ok(dataAccess.GetGroups(personID));
        }

    }
}
