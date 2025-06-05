using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;
namespace WebAppApi48Core.Controllers
{
    [Route("Api/Prescriptions")]
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
        public IEnumerable<Prescription> Get()
        {
            var personID = this.authService.VerifyCredentials(Request);
            return dataAccess.GetPrescriptions(personID);
        }
        
    }
}