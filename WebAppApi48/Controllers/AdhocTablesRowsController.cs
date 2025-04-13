using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using WebAppApi48.Services;

using Resolver = System.Web.Mvc.DependencyResolver;
namespace WebAppApi48.Controllers
{    
    
    [RoutePrefix("Api/AdhocTables/{adhoctableid}/Rows")]
    public class AdhocTablesRowsController : ApiController
    {        
        public AdhocTablesRowsController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(IAdhocTableRowDataAccess)) as IAdhocTableRowDataAccess;
        }

        private IAuthService authService;
        private IAdhocTableRowDataAccess dataAccess;
        
        [Route("")]
        public IHttpActionResult Get([FromUri]string adhoctableid)
        {
            return base.Ok(dataAccess.GetScenes(int.Parse(adhoctableid)));
        }

        [Route("")]
        public IHttpActionResult Post([FromUri]string adhoctableid, [FromBody]AdhocTableRow body)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            return base.Ok(new { AdhocTableRowID = dataAccess.CreateRow(int.Parse(adhoctableid), body) });
        }

        [Route("")]
        public IHttpActionResult Put([FromUri]string adhoctableid, [FromBody]AdhocTableRow body)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            return base.Ok(new { AdhocTableRowID = dataAccess.UpdateRow(int.Parse(adhoctableid), body) });
        }

        [Route("{rowid}")]
        public IHttpActionResult Delete([FromUri]string adhoctableid, [FromUri]string rowid)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            return base.Ok(dataAccess.DeleteRow(int.Parse(adhoctableid), int.Parse(rowid)));
        }

    }
    
}
