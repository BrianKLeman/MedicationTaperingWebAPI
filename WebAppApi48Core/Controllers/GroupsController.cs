using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;
namespace WebAppApi48Core.Controllers
{    

    [Route("Api/Groups")]
    [Authorize]
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
        public IActionResult Get()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = authService.GetPersonCode(HttpContext);

            return base.Ok(dataAccess.GetGroups(personID));
        }

        [Route("TaskGroups")]
        [HttpGet]
        public IActionResult TaskGroups()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);

            return base.Ok(dataAccess.GetGroups(personID));
        }

    }
}
