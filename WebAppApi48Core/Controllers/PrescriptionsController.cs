using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;
namespace WebAppApi48Core.Controllers
{
    [Route("Api/Prescriptions")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController]
    [Produces("application/json")]
    public class PrescriptionsController : ControllerBase
    {
        public PrescriptionsController(IAuthService authService, IPrescriptionDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
        }

        private IAuthService authService;
        private IPrescriptionDataAccess dataAccess;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Prescription>))]
        public IEnumerable<Prescription> Get()
        {
            var personID = this.authService.GetPersonCode(HttpContext);
            var result = dataAccess.GetPrescriptions(personID);
            return result;
        }
        
    }
}