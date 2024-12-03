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
    public class AlcoholController : ODataController
    {
        public AlcoholController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.repo = new ODataRepository<Alcohol>();
        }

        private IAuthService authService;
        private ODataRepository<Alcohol> repo = null;

        private bool AlcoholItemExists(int key)
        {
            var personID = this.authService.VerifyCredentials(Request);  
            return repo.Get(personID).Any(p => p.Id == key);
        }

        [EnableQuery]
        public IQueryable<Alcohol> Get()
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
        public SingleResult<Alcohol> Get([FromODataUri] int key)
        {
            var personID = this.authService.VerifyCredentials(Request);

            if(personID <= 0)
            {
                personID = this.authService.VerifyReadOnlyCredentials(Request);
                return SingleResult.Create(repo.Get(personID).Where(x => x.Personal == 0 && x.Id == key));
            }
            IQueryable<Alcohol> result = repo.Get(personID).Where(p => p.Id == key);
            return SingleResult.Create(result);
        }

        public async Task<IHttpActionResult> Put([FromODataUri] int key, Alcohol update)
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