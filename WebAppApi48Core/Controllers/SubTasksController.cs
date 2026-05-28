using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;

namespace WebAppApi48Core.Controllers
{    
    [Route("Api/Tasks/{TaskID}/SubTasks")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]   
    [Produces("application/json")]
    public class SubTasksController : ControllerBase
    {        
        public SubTasksController( IAuthService authService, ISubTasksDataAccess subTasksDataAccess )
        {
            this.authService = authService;
            this.subTasksDataAccess = subTasksDataAccess;
        }

        private IAuthService authService;
       
        private ISubTasksDataAccess subTasksDataAccess;

        /// <summary>
        /// Upates a sub task in the database.
        /// </summary>
        /// <param name="body">subTask Model</param>
        /// <returns></returns>
        [HttpPut]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] SubTasks body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);

            return base.Ok(subTasksDataAccess.UpdateSubTask(personID, body));
        }

        /// <summary>
        /// Creates a sub task in the database.
        /// </summary>
        /// <param name="body">subTask Model</param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] SubTasks body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);

            return base.Ok(subTasksDataAccess.CreateSubTask(personID, body));
        }

        /// <summary>
        /// Delete a sub task in the database.
        /// </summary>
        /// <param name="body">subTask Model</param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{subTaskID}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete( uint subTaskID)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);
            return base.Ok(subTasksDataAccess.DeleteSubTask(personID, subTaskID));
        }
    }
}
