using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;
namespace WebAppApi48Core.Controllers
{    
    
    [Route("Api/AdhocTables/{adhoctableid}/Rows")]
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    public class AdhocTablesRowsController : ControllerBase
    {        
        public AdhocTablesRowsController(IAuthService authService, IAdhocTableRowDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
        }

        private IAuthService authService;
        private IAdhocTableRowDataAccess dataAccess;
        
        [Route("")]
        [HttpGet]
        public IActionResult Get([FromRoute]string adhoctableid)
        {
            return base.Ok(dataAccess.GetScenes(int.Parse(adhoctableid)));
        }

        [Route("")]
        [HttpPost]
        public IActionResult Post([FromRoute]string adhoctableid, [FromBody]AdhocTableRow body)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            return base.Ok(new { AdhocTableRowID = dataAccess.CreateRow(int.Parse(adhoctableid), body) });
        }

        [Route("")]
        [HttpPut]
        public IActionResult Put([FromRoute]string adhoctableid, [FromBody]AdhocTableRow body)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            return base.Ok(new { AdhocTableRowID = dataAccess.UpdateRow(int.Parse(adhoctableid), body) });
        }

        [Route("{rowid}")]
        [HttpDelete]
        public IActionResult Delete([FromRoute]string adhoctableid, [FromRoute]string rowid)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            return base.Ok(dataAccess.DeleteRow(int.Parse(adhoctableid), int.Parse(rowid)));
        }

    }
    
}
