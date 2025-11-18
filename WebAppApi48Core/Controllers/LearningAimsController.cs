using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;

namespace WebAppApi48Core.Controllers
{
    public class LearningAimsRequest
    {
        public long PersonID { get; set; }
    }   

    [Route("Api/LearningAims")]
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

            var personID = this.authService.VerifyCredentials(Request);

            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);
            return base.Ok(dataAccess.GetAims(personID));
        }      

    }
}
