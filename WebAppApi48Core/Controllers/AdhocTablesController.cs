using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;
namespace WebAppApi48Core.Controllers
{    
    
    [Route("Api/AdhocTables")]
    [Authorize]
    public class AdhocTablesController : ControllerBase
    {        
        public AdhocTablesController(IAuthService authService, IAdhocTablesDataAccess adhocTablesDataAccess)
        {
            this.authService = authService;
            this.dataAccess = adhocTablesDataAccess;             
        }

        private IAuthService authService;
        private IAdhocTablesDataAccess dataAccess;

        [HttpGet]
        public IActionResult Get()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);

            return base.Ok(dataAccess.GetAdhocTables(personID));
        }

        [HttpPost]
        public IActionResult Post([FromBody] AdhocTable model)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);
            return base.Ok( new AdhocTable() { Id = dataAccess.CreateNewTable(personID, model.ProjectID, model.Name), Name = model.Name, ProjectID = model.ProjectID, PersonID = personID });
        }

        [Route("/{tableID}")]
        [HttpDelete]
        public IActionResult Delete([FromRoute] string tableID)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);

            return base.Ok( dataAccess.DeleteTable(personID, int.Parse(tableID)));
        }

    }
    
}
