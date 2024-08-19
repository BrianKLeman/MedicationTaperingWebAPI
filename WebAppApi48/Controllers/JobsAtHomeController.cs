using DataAccessLayer;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using WebAppApi48.Services;
using Resolver = System.Web.Mvc.DependencyResolver;

namespace WebAppApi48.Controllers
{


    public class LogActivity
    {
        [Required]
        public long JobID { get; set; }
        public DateTime? Date { get; set; }
    }
    [RoutePrefix("Api/JobsAtHome")]
    public class JobsAtHomeController : ApiController
    {
        public JobsAtHomeController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(IJobsAtHomeViewsDataAccess)) as IJobsAtHomeViewsDataAccess;
            this.activityLogDataAccess = Resolver.Current.GetService(typeof(IJobsAtHomeLogDataAccess)) as IJobsAtHomeLogDataAccess;
        }

        private IAuthService authService;
        private IJobsAtHomeViewsDataAccess dataAccess;
        private IJobsAtHomeLogDataAccess activityLogDataAccess;

        [HttpGet()]
        [Route("Summary")]
        public IHttpActionResult JobsAtHomeSummary()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            return Ok(dataAccess.GetsJobsAtHomeSummary(personID));
        }

        [HttpPost()]
        [Route("Log")]
        public IHttpActionResult LogActivity([FromBody] LogActivity jobAtHome)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            return Ok(activityLogDataAccess.AddActivity(personID, jobAtHome.JobID, jobAtHome.Date ?? DateTime.Now ));
        }

    }
}