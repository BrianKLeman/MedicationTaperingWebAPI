using DataAccessLayer;
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

        [HttpGet()]
        public IHttpActionResult Tasks()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            return base.Ok(dataAccess.GetTasks(personID));
        }

        [HttpGet()]
        public IHttpActionResult Tasks(string tableName, long entityID)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            
            return base.Ok(dataAccess.GetTasks(personID, tableName, entityID));
        }      

    }
}
