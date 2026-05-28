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

        [HttpPut("{roadmapID:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] RoadMap body, uint roadmapID)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);

            body.Id = roadmapID;
            return base.Ok(dataAccess.UpdateRoadMap(personID, body));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] RoadMap body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);


            return base.Ok(dataAccess.CreateRoadMap(personID, body));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromBody] RoadMap body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);

            return base.Ok(dataAccess.DeleteRoadMap(personID, body));
        }

    }
}