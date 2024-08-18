using DataAccessLayer;
using System.Web.Http;
using WebAppApi48.Services;

using Resolver = System.Web.Mvc.DependencyResolver;
namespace WebAppApi48.Controllers
{    

    [RoutePrefix("Api/Appointments")]
    public class AppointmentsController : ApiController
    {        
        public AppointmentsController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(IAppointmentsDataAccess)) as IAppointmentsDataAccess;
        }

        private IAuthService authService;
        private IAppointmentsDataAccess dataAccess;

        [HttpGet()]
        public IHttpActionResult Appointments()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            
            return base.Ok(dataAccess.GetAppointments(personID));
        }      

    }
}
