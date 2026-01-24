using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.IntegrationControllers.HackNPlan;
using WebAppApi48Core.IntegrationControllers.HackNPlan.HackNPlanModels;
using WebAppApi48Core.Services;


namespace WebAppApi48.Integration.Controllers
{
    [Route("Api/Integration/Projects")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController]
    [Produces("application/json")]
    public class ProjectsIntegrationController : ControllerBase
    {
        public ProjectsIntegrationController(IAuthService authService, IProjectsDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
        }

        private IAuthService authService;
        private IProjectsDataAccess dataAccess;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Projects>))]
        public IEnumerable<Projects> Get()
        {
            var personID = this.authService.GetPersonCode(HttpContext);
            return dataAccess.GetProjects(personID, true);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Projects>))]
        [Route("UpdateProject")]
        public IActionResult UpdateProject([FromBody]HackNPlanProject project)
        {
            var personID = this.authService.GetPersonCode(HttpContext);
            var p = dataAccess.GetProjects(personID, true).FirstOrDefault(pr => pr.ExtProjectID == project.Id);

            if(p == null)
            {
                return NotFound("Project not found");
            }
            dataAccess.UpdateProject(personID, project.ToProject(personID, p.Id));
            return Ok();
        }
    }
}