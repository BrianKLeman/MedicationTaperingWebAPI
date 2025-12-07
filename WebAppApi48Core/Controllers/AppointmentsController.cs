using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Description;
using WebAppApi48Core.Services;
namespace WebAppApi48Core.Controllers
{    
    
    [Route("Api/Appointments")]

    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController]
    [Produces("application/json")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {           

            long personID = authService.GetPersonCode(HttpContext);
            
            return base.Ok(dataAccess.GetAppointments(personID));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Appointments appointment)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            long personID = authService.GetPersonCode(HttpContext);

            return base.Ok(dataAccess.InsertAppointment(personID, appointment));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] Appointments appointment)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            long personID = authService.GetPersonCode(HttpContext);

            return base.Ok(dataAccess.UpdateAppointment(personID, appointment));
        }
        
        [Route("{appointmentID:long}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromRoute] long appointmentID)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            long personID = authService.GetPersonCode(HttpContext);

            return base.Ok(dataAccess.DeleteAppointment(personID, appointmentID));
        }

    }
}
