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
            var personID = this.authService.GetPersonCode(HttpContext);  
            return repo.Get(personID).Any(p => p.Id == key);
        }

        [EnableQuery]
        public IQueryable<ShoppingItems> Get()
        {
            var personID = this.authService.GetPersonCode(HttpContext);            
            return repo.Get(personID);
        }
        
        [EnableQuery]        
        public SingleResult<ShoppingItems> Get([FromRoute] int key)
        {
            var personID = this.authService.GetPersonCode(HttpContext);

           
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

            var personID = this.authService.GetPersonCode(HttpContext);
       

            await this.repo.Update(personID, update);
            
            return Updated(update);
        }
    }
}