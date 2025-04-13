using DataAccessLayer;
using DataAccessLayer.Models;
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


        public IHttpActionResult Get()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            
            return base.Ok(dataAccess.GetAppointments(personID));
        }    
        
        public IHttpActionResult Post([FromBody] Appointments appointment)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            
            return base.Ok(dataAccess.InsertAppointment(personID, appointment));
        }  
        
        public IHttpActionResult Put([FromBody] Appointments appointment)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            
            return base.Ok(dataAccess.UpdateAppointment(personID, appointment));
        }
        
        [Route("{appointmentID:long}")]
        public IHttpActionResult Delete([FromUri] long appointmentID)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            return base.Ok(dataAccess.DeleteAppointment(personID, appointmentID));
        }

    }
}
