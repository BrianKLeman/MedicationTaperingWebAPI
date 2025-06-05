using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;

namespace WebAppApi48Core.Controllers
{
    [Route("Api/Phenomena")]
    public class PhenomenaController : ControllerBase
    {
        public PhenomenaController(IAuthService authService, IPhenomenaDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
        }

        private IAuthService authService;
        private IPhenomenaDataAccess dataAccess;

        [HttpGet]
        public IEnumerable<Phenomena> Get()
        {
            var personID = this.authService.VerifyCredentials(Request);
            return dataAccess.GetPhenomena(personID);
        }
        
    }
}