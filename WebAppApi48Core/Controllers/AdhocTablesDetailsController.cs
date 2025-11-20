using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;
namespace WebAppApi48Core.Controllers
{    
    
    [Route("Api/AdhocTables/{adhoctableid}/Details")]
    [Authorize]
    public class AdhocTablesDetailsController : ControllerBase
    {        
        public AdhocTablesDetailsController(IAuthService authService, IAdhocTablesDetailsDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
        }

        private IAuthService authService;
        private IAdhocTablesDetailsDataAccess dataAccess;
        
        [Route("")]
        [HttpGet]
        public IActionResult Get([FromRoute]string adhoctableid)
        {
            return base.Ok(dataAccess.GetDetails(int.Parse(adhoctableid)));
        }

        [Route("")]
        [HttpPost]
        public IActionResult Post([FromRoute]string adhoctableid, [FromBody]AdhocTablesDetail detail)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            return base.Ok(new { BeatchartDetailID = dataAccess.CreateDetail(int.Parse(adhoctableid), detail) });
        }

        [Route("")]
        [HttpPut]
        public IActionResult Put([FromRoute]string adhoctableid, [FromBody]AdhocTablesDetail detail)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            return base.Ok(new { BeatchartDetailID = dataAccess.UpdateDetail(int.Parse(adhoctableid), detail) });
        }

    }
    
}
