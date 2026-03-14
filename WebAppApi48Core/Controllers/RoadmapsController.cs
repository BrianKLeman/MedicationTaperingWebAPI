using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;

namespace WebAppApi48.Controllers
{
    [Route("Api/RoadMaps")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController]
    [Produces("application/json")]
    public class RoadMapsController : ControllerBase
    {
        public RoadMapsController(IAuthService authService, IRoadMapsDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
        }

        private IAuthService authService;
        private IRoadMapsDataAccess dataAccess;


        [ProducesResponseType(typeof(IEnumerable<RoadMap>),StatusCodes.Status200OK)]
        [HttpGet]
        public IEnumerable<RoadMap> Get(long projectID, long learningAimID)
        {
            var personID = this.authService.GetPersonCode(HttpContext);

            if (projectID > 0)
                return dataAccess.GetRoadMapsForProjectID(personID, projectID).ToList();

            if(learningAimID > 0)
                return dataAccess.GetRoadMapsForLearningAimID(personID, learningAimID);

            return dataAccess.GetRoadMaps(personID, true);
        }
        
    }
}