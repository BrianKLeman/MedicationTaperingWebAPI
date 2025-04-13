using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using WebAppApi48.Services;

using Resolver = System.Web.Mvc.DependencyResolver;
namespace WebAppApi48.Controllers
{    
    
    [RoutePrefix("Api/AdhocTables")]
    [Route("{action=Get}")]
    public class AdhocTablesController : ApiController
    {        
        public AdhocTablesController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(IAdhocTablesDataAccess)) as IAdhocTablesDataAccess;            
        }

        private IAuthService authService;
        private IAdhocTablesDataAccess dataAccess;
        
        public IHttpActionResult Get()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            return base.Ok(dataAccess.GetAdhocTables(personID));
        }

        [Route("")]
        public IHttpActionResult Post([FromBody] AdhocTable model)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            return base.Ok( new AdhocTable() { Id = dataAccess.CreateNewTable(personID, model.ProjectID, model.Name), Name = model.Name, ProjectID = model.ProjectID, PersonID = personID });
        }

        [Route("{tableID}")]
        public IHttpActionResult Delete([FromUri] string tableID)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            return base.Ok( dataAccess.DeleteTable(personID, int.Parse(tableID)));
        }

    }
    
}
