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


        [ProducesResponseType(typeof(IEnumerable<Feature>),StatusCodes.Status200OK)]
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Feature body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);
            return base.Ok(dataAccess.CreateFeature(personID, body));
        }

        [HttpPut("{featureID:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] Feature body, uint featureID)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);
            return base.Ok(dataAccess.UpdateFeature(personID, body));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromBody] Feature body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);
            return base.Ok(dataAccess.DeleteFeature(personID, body));
        }

    }
}