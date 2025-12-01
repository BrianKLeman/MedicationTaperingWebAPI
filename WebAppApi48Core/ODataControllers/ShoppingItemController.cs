
using DataAccessLayer.Repository;
using WebAppApi48Core.Services;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Data.Services.Interfaces.IRespository;
using test;

namespace WebAppApi48.OData.Controllers
{
    [Authorize]
    public class ShoppingItemsController : ODataController
    {
        public ShoppingItemsController(IAuthService authService, IODataRepository<ShoppingItem> repo)
        {
            this.authService = authService;
            this.repo = repo;
        }

        private IAuthService authService;
        private IODataRepository<ShoppingItem> repo = null;

        private bool ShoppingItemExists(int key)
        {
            var personID = this.authService.GetPersonCode(HttpContext);  
            return repo.Get(personID).Any(p => p.Id == key);
        }

        [EnableQuery]
        public IQueryable<ShoppingItem> Get()
        {
            var personID = this.authService.GetPersonCode(HttpContext);            
            return repo.Get(personID);
        }
        
        [EnableQuery]        
        public SingleResult<ShoppingItem> Get([FromRoute] int key)
        {
            var personID = this.authService.GetPersonCode(HttpContext);

           
            IQueryable<ShoppingItem> result = repo.Get(personID).Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IActionResult> Put([FromRoute] int key, ShoppingItem update)
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