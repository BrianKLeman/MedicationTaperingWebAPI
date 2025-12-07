using Data.Services.Interfaces.IRespository;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;

namespace WebAppApi48.Controllers
{
    [Route("Api/Sleeps")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController]
    [Produces("application/json")]
    public class SleepsController : ControllerBase
    {
        public SleepsController(IAuthService authService, ISleepsDataAccess dataAccess, IODataRepository<test.Sleep> sleepsRepository)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
            this.sleepsRepository = sleepsRepository;
        }

        private IAuthService authService;
        private ISleepsDataAccess dataAccess;
        private IODataRepository<test.Sleep> sleepsRepository;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<test.Sleep>))]
        public IEnumerable<test.Sleep> Get()
        {
            var personID = this.authService.GetPersonCode(HttpContext);
            return sleepsRepository.Get(personID);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] Sleeps body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);

            return base.Ok(dataAccess.UpdateSleeps(personID, body));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Sleeps body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);


            return base.Ok(dataAccess.CreateSleeps(personID, body));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromBody] Sleeps body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);

            return base.Ok(dataAccess.DeleteSleeps(personID, body));
        }

    }
}