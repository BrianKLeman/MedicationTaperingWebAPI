using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using WebAppApi48.Services;

using Resolver = System.Web.Mvc.DependencyResolver;
namespace WebAppApi48.Controllers
{    
    
    [RoutePrefix("Api/AdhocTables/{adhoctableid}/Details")]
    public class AdhocTablesDetailsController : ApiController
    {        
        public AdhocTablesDetailsController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(IAdhocTablesDetailsDataAccess)) as IAdhocTablesDetailsDataAccess;
        }

        private IAuthService authService;
        private IAdhocTablesDetailsDataAccess dataAccess;
        
        [Route("")]
        public IHttpActionResult Get([FromUri]string adhoctableid)
        {
            return base.Ok(dataAccess.GetDetails(int.Parse(adhoctableid)));
        }

        [Route("")]
        public IHttpActionResult Post([FromUri]string adhoctableid, [FromBody]AdhocTablesDetail detail)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            return base.Ok(new { BeatchartDetailID = dataAccess.CreateDetail(int.Parse(adhoctableid), detail) });
        }

        [Route("")]
        public IHttpActionResult Put([FromUri]string adhoctableid, [FromBody]AdhocTablesDetail detail)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            return base.Ok(new { BeatchartDetailID = dataAccess.UpdateDetail(int.Parse(adhoctableid), detail) });
        }

    }
    
}
