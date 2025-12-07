using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;
namespace WebAppApi48Core.Controllers
{    

    [Route("Api/Groups")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController]
    [Produces("application/json")]
    public class GroupsController : ControllerBase
    {        
        public GroupsController(IAuthService authService, IGroupsDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;            
        }

        private IAuthService authService;
        private IGroupsDataAccess dataAccess;

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type=typeof(IEnumerable<Groups>))]
        public IActionResult Get()
        {
            var personID = authService.GetPersonCode(HttpContext);
            return base.Ok(dataAccess.GetGroups(personID));
        }
    }
}
