using DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using WebAppApi48.Services;
using Resolver = System.Web.Mvc.DependencyResolver;

namespace WebAppApi48.Controllers
{

    public class TaskLinks
    {
        [Required]
        public string Table { get; set; }

        [Required]
        public long EntityID { get; set; }

        [Required]
        public long[] TaskIDs { get; set; }
    }

    [RoutePrefix("Api/TaskLinks")]
    public class TaskLinksController : ApiController
    {
        public TaskLinksController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(ITableTasksLinksDataAccess)) as ITableTasksLinksDataAccess;
        }

        private IAuthService authService;
        private ITableTasksLinksDataAccess dataAccess;       
        
        public IHttpActionResult Post([FromBody] TaskLinks requestModel)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            return Ok(dataAccess.Insert(personID, requestModel.TaskIDs, requestModel.Table, requestModel.EntityID));
        }

    }
}