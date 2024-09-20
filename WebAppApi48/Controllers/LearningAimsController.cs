using DataAccessLayer;
using System.Web.Http;
using WebAppApi48.Services;

using Resolver = System.Web.Mvc.DependencyResolver;
namespace WebAppApi48.Controllers
{
    public class LearningAimsRequest
    {
        public long PersonID { get; set; }
    }   

    [RoutePrefix("Api/LearningAims")]
    public class LearningAimsController : ApiController
    {        
        public LearningAimsController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(ILearningAimsDataAccess)) as ILearningAimsDataAccess;
        }

        private IAuthService authService;
        private ILearningAimsDataAccess dataAccess;
        
        public IHttpActionResult Get()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);
            return base.Ok(dataAccess.GetAims(personID));
        }      

    }
}
