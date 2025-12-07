using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;

namespace WebAppApi48.Controllers
{
    [Route("Api/Projects")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController]
    [Produces("application/json")]
    public class ProjectsController : ControllerBase
    {
        public ProjectsController(IAuthService authService, IProjectsDataAccess dataAccess)
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
        
    }
}