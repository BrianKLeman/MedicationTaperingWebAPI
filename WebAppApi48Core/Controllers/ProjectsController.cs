using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;

namespace WebAppApi48.Controllers
{
    [Route("Api/Projects")]
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
        public IEnumerable<Projects> Get()
        {
            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            return dataAccess.GetProjects(personID, includePersonal);
        }
        
    }
}