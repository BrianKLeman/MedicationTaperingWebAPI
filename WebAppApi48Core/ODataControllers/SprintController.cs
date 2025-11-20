using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using WebAppApi48Core.Services;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace WebAppApi48.OData.Controllers
{
    [Authorize]
    public class SprintsController : ODataController
    {
        public SprintsController(IAuthService authService, IConnectionStringProvider connectionStringProvider)
        {
            this.authService = authService;
            this.repo = new ODataRepository<Sprint>(connectionStringProvider);
        }

        private IAuthService authService;
        private ODataRepository<Sprint> repo = null;

        private bool SprintExists(int key)
        {
            var personID = this.authService.GetPersonCode(HttpContext);  
            return repo.Get(personID).Any(p => p.Id == key);
        }

        [EnableQuery]
        public IQueryable<Sprint> Get()
        {
            var personID = this.authService.GetPersonCode(HttpContext);
           
            return repo.Get(personID);
        }
        
        [EnableQuery]        
        public SingleResult<Sprint> Get([FromRoute] int key)
        {
            var personID = this.authService.GetPersonCode(HttpContext);

            
            IQueryable<Sprint> result = repo.Get(personID).Where(p => p.Id == key);
            return SingleResult.Create(result);
        }       
    }
}