using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using WebAppApi48Core.Services;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebAppApi48.OData.Controllers
{
    public class ShoppingItemsController : ODataController
    {
        public ShoppingItemsController(IAuthService authService, IConnectionStringProvider connectionStringProvider)
        {
            this.authService = authService;
            this.repo = new ODataRepository<ShoppingItems>(connectionStringProvider);
        }

        private IAuthService authService;
        private ODataRepository<ShoppingItems> repo = null;

        private bool ShoppingItemExists(int key)
        {
            var personID = this.authService.VerifyCredentials(Request);  
            return repo.Get(personID).Any(p => p.Id == key);
        }

        [EnableQuery]
        public IQueryable<ShoppingItems> Get()
        {
            var personID = this.authService.VerifyCredentials(Request);
            if (personID < 0)
            {
                personID = this.authService.VerifyReadOnlyCredentials(Request);
                return repo.Get(personID).Where( x => x.Personal == 0);
            }
            else
                return repo.Get(personID);
        }
        
        [EnableQuery]        
        public SingleResult<ShoppingItems> Get([FromRoute] int key)
        {
            var personID = this.authService.VerifyCredentials(Request);

            if(personID <= 0)
            {
                personID = this.authService.VerifyReadOnlyCredentials(Request);
                return SingleResult.Create(repo.Get(personID).Where(x => x.Personal == 0 && x.Id == key));
            }
            IQueryable<ShoppingItems> result = repo.Get(personID).Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IActionResult> Put([FromRoute] int key, ShoppingItems update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (key != update.Id)
            {
                return BadRequest();
            }

            var personID = this.authService.VerifyCredentials(Request);

            if (personID < 0)
                return this.Unauthorized();            

            await this.repo.Update(personID, update);
            
            return Updated(update);
        }
    }
}