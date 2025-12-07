using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;

namespace WebAppApi48Core.Controllers
{
    public class LearningAimsRequest
    {
        public long PersonID { get; set; }
    }   

    [Route("Api/LearningAims")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController]
    [Produces("application/json")]
    public class LearningAimsController : ControllerBase
    {        
        public LearningAimsController(IAuthService authService, ILearningAimsDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
        }

        private IAuthService authService;
        private ILearningAimsDataAccess dataAccess;

        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);
           
            return base.Ok(dataAccess.GetAims(personID));
        }      

    }
}
