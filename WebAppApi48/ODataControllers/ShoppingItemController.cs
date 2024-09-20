using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System.Linq;
using Microsoft.AspNet.OData;
using WebAppApi48.Services;

using Resolver = System.Web.Mvc.DependencyResolver;
using System.Web.Http;
using System.Threading.Tasks;

namespace WebAppApi48.OData.Controllers
{
    public class ShoppingItemsController : ODataController
    {
        public ShoppingItemsController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.repo = new ODataRepository<ShoppingItems>();
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
                personID = this.authService.VerifyReadOnlyCredentials(Request);
            return repo.Get(personID);
        }
        
        [EnableQuery]        
        public SingleResult<ShoppingItems> Get([FromODataUri] int key)
        {
            var personID = this.authService.VerifyCredentials(Request);
            IQueryable<ShoppingItems> result = repo.Get(personID).Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, ShoppingItems update)
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