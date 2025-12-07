using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;

namespace WebAppApi48.Controllers
{
    [Route("Api/Features")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController]
    [Produces("application/json")]
    public class FeaturesController : ControllerBase
    {
        public FeaturesController(IAuthService authService, IFeaturesDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
        }

        private IAuthService authService;
        private IFeaturesDataAccess dataAccess;


        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public IEnumerable<Feature> Get(long projectID, long learningAimID)
        {
            var personID = this.authService.GetPersonCode(HttpContext);

            if (projectID > 0)
                return dataAccess.GetFeaturesForProjectID(personID, projectID).ToList();

            if(learningAimID > 0)
                return dataAccess.GetFeaturesForLearningAimID(personID, learningAimID);

            return dataAccess.GetFeatures(personID, true);
        }
        
    }
}