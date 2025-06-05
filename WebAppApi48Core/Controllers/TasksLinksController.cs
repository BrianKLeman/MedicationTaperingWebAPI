using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAppApi48Core.Services;

namespace WebAppApi48Core.Controllers
{

    public class TaskLinks
    {
        [Required]
        public string Table { get; set; }

        [Required]
        public long EntityID { get; set; }

        [Required]
        public long[] TaskIDs { get; set; }
    }

    [Route("Api/TaskLinks")]
    public class TaskLinksController : ControllerBase
    {
        public TaskLinksController(IAuthService authService, ITableTasksLinksDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
        }

        private IAuthService authService;
        private ITableTasksLinksDataAccess dataAccess;       
        
        public IActionResult Post([FromBody] TaskLinks requestModel)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            return Ok(dataAccess.Insert(personID, requestModel.TaskIDs, requestModel.Table, requestModel.EntityID));
        }

        [Route("GetGroups")]
        [HttpPost]
        public IActionResult GetGroups([FromBody] TaskLinks requestModel)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            if(requestModel.EntityID == 0)
                return Ok(dataAccess.Select(personID, requestModel.TaskIDs, requestModel.Table));
            else
                return Ok(dataAccess.Select(personID, requestModel.TaskIDs, requestModel.Table, requestModel.EntityID));
        }

    }
}