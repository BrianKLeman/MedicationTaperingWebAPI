
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
    public class AlcoholController : ODataController
    {
        public AlcoholController( IAuthService authService, IODataRepository<Alcohol> alcoholRepository)
        {
            this.authService = authService;
            this.repo = alcoholRepository;
        }

        private IAuthService authService;
        private IODataRepository<Alcohol> repo = null;

        private bool AlcoholItemExists(int key)
        {
            var personID = this.authService.GetPersonCode(HttpContext);  
            return repo.Get(personID).Any(p => p.Id == key);
        }

        [EnableQuery]
        public IQueryable<Alcohol> Get()
        {
             var personID = this.authService.GetPersonCode(HttpContext);            
             return repo.Get(personID);
        }
        
        [EnableQuery]        
        public SingleResult<Alcohol> Get([FromRoute] int key)
        {
            var personID = this.authService.GetPersonCode(HttpContext);

            
            IQueryable<Alcohol> result = repo.Get(personID).Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IActionResult> Put([FromRoute] int key, Alcohol update)
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