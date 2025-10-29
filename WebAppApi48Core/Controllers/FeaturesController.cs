using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;

namespace WebAppApi48.Controllers
{
    [Route("Api/Features")]
    public class FeaturesController : ControllerBase
    {
        public FeaturesController(IAuthService authService, IFeaturesDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
        }

        private IAuthService authService;
        private IFeaturesDataAccess dataAccess;

        [HttpGet]
        public IEnumerable<Feature> Get(long projectID, long learningAimID)
        {
            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            if (projectID > 0)
                return dataAccess.GetFeaturesForProjectID(personID, projectID).ToList();

            if(learningAimID > 0)
                return dataAccess.GetFeaturesForLearningAimID(personID, learningAimID);

            return dataAccess.GetFeatures(personID, includePersonal);
        }
        
    }
}