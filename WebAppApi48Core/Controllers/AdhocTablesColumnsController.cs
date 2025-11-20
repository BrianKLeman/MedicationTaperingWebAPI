using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;

namespace WebAppApi48Core.Controllers
{    
    
    [Route("Api/AdhocTables/{adhoctableid}/Columns")]
    [Authorize]
    public class AdhocTableColumnsController : ControllerBase
    {        
        public AdhocTableColumnsController(IAdhocColumnDataAccess adhocColumnDataAccess)
        {
            this.dataAccess = adhocColumnDataAccess;
        }

        private IAdhocColumnDataAccess dataAccess;
        
        [HttpGet()]
        public IActionResult Get([FromRoute]string adhoctableid)
        {
            return Ok(dataAccess.GetColumns(int.Parse(adhoctableid)));
        }

        [Route("{columnName}")]
        [HttpPost]
        public IActionResult Post([FromRoute]string adhoctableid, [FromRoute]string columnName)
        {
            return base.Ok(new { AdhocTableColumnID = dataAccess.CreateColumn(int.Parse(adhoctableid), columnName) });
        }

        [Route("{columnId}")]
        [HttpDelete]
        public IActionResult Delete([FromRoute]string adhoctableid, [FromRoute]string columnId)
        {
            return base.Ok(dataAccess.DeleteColumn(int.Parse(adhoctableid), int.Parse(columnId)));
        }
    }    
}
