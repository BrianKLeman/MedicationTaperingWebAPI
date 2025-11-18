using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;

namespace WebAppApi48.Controllers
{
    [Route("Api/Sleeps")]
    public class SleepsController : ControllerBase
    {
        public SleepsController(IAuthService authService, ISleepsDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
        }

        private IAuthService authService;
        private ISleepsDataAccess dataAccess;

        [HttpGet]
        public IEnumerable<Sleeps> Get()
        {
            var personID = this.authService.VerifyCredentials(Request);
            return dataAccess.GetSleeps(personID);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Sleeps body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            return base.Ok(dataAccess.UpdateSleeps(personID, body));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Sleeps body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            if (personID < 1)
                return Unauthorized();

            return base.Ok(dataAccess.CreateSleeps(personID, body));
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Sleeps body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            if (personID < 1)
                return Unauthorized();

            return base.Ok(dataAccess.DeleteSleeps(personID, body));
        }

    }
}