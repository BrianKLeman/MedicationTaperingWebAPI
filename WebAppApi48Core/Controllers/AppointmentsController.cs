using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;
namespace WebAppApi48Core.Controllers
{    
    
    [Route("Api/Appointments")]
    public class AppointmentsController : ControllerBase
    {        
        public AppointmentsController(IAuthService authService, IAppointmentsDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
        }

        private IAuthService authService;
        private IAppointmentsDataAccess dataAccess;

        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            
            return base.Ok(dataAccess.GetAppointments(personID));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Appointments appointment)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            
            return base.Ok(dataAccess.InsertAppointment(personID, appointment));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Appointments appointment)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            
            return base.Ok(dataAccess.UpdateAppointment(personID, appointment));
        }
        
        [Route("{appointmentID:long}")]
        [HttpDelete]
        public IActionResult Delete([FromRoute] long appointmentID)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            return base.Ok(dataAccess.DeleteAppointment(personID, appointmentID));
        }

    }
}
