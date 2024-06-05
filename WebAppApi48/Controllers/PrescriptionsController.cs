using DataAccessLayer;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Web.Http;
using WebAppApi48.Attributes;

namespace WebAppApi48.Controllers
{
    [RoutePrefix("Prescriptions")]
    [Route("{action=Get}")]
    public class PrescriptionsController : ApiController
    {
        public PrescriptionsController()
        {

        }

        public IEnumerable<Prescription> Get()
        {
            return DataAccess.GetPrescriptions();
        }
        
    }
}