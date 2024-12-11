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
    public class SprintsController : ODataController
    {
        public SprintsController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.repo = new ODataRepository<Sprint>();
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
        public SingleResult<Sprint> Get([FromODataUri] int key)
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