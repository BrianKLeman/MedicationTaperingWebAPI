using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using WebAppApi48Core.Services;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAppApi48.OData.Controllers
{
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
            var personID = this.authService.VerifyCredentials(Request);  
            return repo.Get(personID).Any(p => p.Id == key);
        }

        [EnableQuery]
        public IQueryable<Sprint> Get()
        {
            var personID = this.authService.VerifyCredentials(Request);
            if (personID < 0)
            {
                personID = this.authService.VerifyReadOnlyCredentials(Request);
            }
            
            return repo.Get(personID);
        }
        
        [EnableQuery]        
        public SingleResult<Sprint> Get([FromRoute] int key)
        {
            var personID = this.authService.VerifyCredentials(Request);

            if(personID <= 0)
            {
                personID = this.authService.VerifyReadOnlyCredentials(Request);
                return SingleResult.Create(repo.Get(personID).Where(x => x.Id == key));
            }
            IQueryable<Sprint> result = repo.Get(personID).Where(p => p.Id == key);
            return SingleResult.Create(result);
        }       
    }
}