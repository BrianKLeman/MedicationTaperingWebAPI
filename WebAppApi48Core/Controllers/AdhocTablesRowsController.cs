using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;
namespace WebAppApi48Core.Controllers
{    
    
    public class AdhocTableRowResponseMessage
    {
        public long AdhocTableRowID { get; set; }
    }

    [Route("Api/AdhocTables/{adhoctableid}/Rows")]
    [Authorize]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<AdhocTableRow> Get([FromRoute]string adhoctableid)
        {
            return dataAccess.GetScenes(int.Parse(adhoctableid));
        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType(typeof(AdhocTableRowResponseMessage), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromRoute]string adhoctableid, [FromBody]AdhocTableRow body)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            return Ok(new AdhocTableRowResponseMessage{ AdhocTableRowID = dataAccess.CreateRow(int.Parse(adhoctableid), body) });
        }

        [Route("")]
        [HttpPut]
        [ProducesResponseType(typeof(AdhocTableRowResponseMessage), StatusCodes.Status200OK)]
        public IActionResult Put([FromRoute]string adhoctableid, [FromBody]AdhocTableRow body)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            return base.Ok(new AdhocTableRowResponseMessage{ AdhocTableRowID = dataAccess.UpdateRow(int.Parse(adhoctableid), body) });
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
