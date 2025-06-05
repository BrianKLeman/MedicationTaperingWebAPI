using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;
namespace WebAppApi48Core.Controllers
{    

    [Route("Api/Groups")]
    public class GroupsController : ControllerBase
    {        
        public GroupsController(IAuthService authService, IGroupsDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;            
        }

        private IAuthService authService;
        private IGroupsDataAccess dataAccess;
        
        public IActionResult Get()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            return base.Ok(dataAccess.GetGroups(personID));
        }

        [Route("TaskGroups")]
        public IActionResult TaskGroups()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            return base.Ok(dataAccess.GetGroups(personID));
        }

    }
}
