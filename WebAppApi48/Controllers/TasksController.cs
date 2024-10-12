using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using WebAppApi48.Services;

using Resolver = System.Web.Mvc.DependencyResolver;
namespace WebAppApi48.Controllers
{    

    [RoutePrefix("Api/Tasks")]
    public class TasksController : ApiController
    {        
        public TasksController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(ITasksDataAccess)) as ITasksDataAccess;
        }

        private IAuthService authService;
        private ITasksDataAccess dataAccess;
        
        public IHttpActionResult Get()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            return base.Ok(dataAccess.GetTasks(personID, includePersonal));
        }
        
        public IHttpActionResult Get(string tableName, long entityID)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            return base.Ok(dataAccess.GetTasks(personID, tableName, entityID, includePersonal));
        }

        
        public IHttpActionResult Put([FromBody] Tasks body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            return base.Ok(dataAccess.UpdateTask(personID, body));
        }

        public IHttpActionResult Post([FromBody] Tasks body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            if (personID < 1)
                return Unauthorized();

            return base.Ok(dataAccess.CreateTask(personID, body));
        }

    }
}
