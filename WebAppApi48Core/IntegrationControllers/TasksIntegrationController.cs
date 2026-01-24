using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.IntegrationControllers.HackNPlan;
using WebAppApi48Core.IntegrationControllers.HackNPlan.HackNPlanModels;
using WebAppApi48Core.Services;

namespace WebAppApi48Core.Integration.Controllers
{

    [Route("Api/Integration/Tasks")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]   
    [Produces("application/json")]
    public class IntegrationTasksController : ControllerBase
    {        
        public IntegrationTasksController( IAuthService authService, ITasksDataAccess dataAccess, ITableTasksLinksDataAccess tasksDataAccess, IConnectionStringProvider connectionStringProvider, IProjectsDataAccess projectsDataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
            this.tasksLinksDataAccess = tasksDataAccess;
            this.odataDataAccess = new ODataRepository<Sprint>(connectionStringProvider);
            this.projectsDataAccess = projectsDataAccess;
        }

        private IAuthService authService;
        private ITasksDataAccess dataAccess;
        private ODataRepository<Sprint> odataDataAccess;
        private ITableTasksLinksDataAccess tasksLinksDataAccess;
        private IProjectsDataAccess projectsDataAccess;

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] WorkItem workItem)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);

            var existingTask = this.dataAccess.GetTasksByExtID(personID, workItem.WorkItemId);
            uint taskID = 0;
            if (existingTask != null)
            {
                // Update existing task
                var result = dataAccess.UpdateTask(personID, workItem.ToTask(personID, existingTask.Id));
                taskID = existingTask.Id;
            }
            else
            {
                var result = dataAccess.CreateTask(personID, workItem.ToNewTask(personID));
                taskID = (uint)result;
            }

            // Create project link
            var projectID = GetProjectID((uint)workItem.ProjectId, personID);
            if(projectID > 0) // We have the project created
                this.tasksLinksDataAccess.Insert(personID, new[] { taskID }, "PROJECTS", projectID);

            // Create sprint link
            if (workItem.Board != null) // can only link it if we have a board
            {
                var sprintID = GetSprintID((uint)workItem.Board.BoardId, personID);
                if (sprintID > 0) // We have the sprint created
                    this.tasksLinksDataAccess.Insert(personID, new [] {taskID}, "SPRINTS", sprintID);
            }
            return base.Ok();
        }

        uint GetSprintID(uint boardID, uint personID)
        {
            var existing = odataDataAccess.Get(personID).FirstOrDefault(s => s.BoardId == boardID);
            return existing?.Id ?? 0;
        }

        uint GetProjectID(uint projectID, uint personID)
        {
            var existing = projectsDataAccess.GetProjects(personID, false).FirstOrDefault(p => p.ExtProjectID == projectID);
            return existing?.Id ?? 0;
        }

        /// <summary>
        /// Deletes the task with id specified in the body.
        /// </summary>
        /// <param name="body">Task object to delete (must include id).</param>
        /// <returns>Deleted task confirmation</returns>
        [HttpPost]
        [Route("DeleteTask")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult DeleteTask([FromBody] WorkItem body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);   

            return base.Ok(dataAccess.DeleteTaskByExternalID(personID, body.WorkItemId));
        }

    }
}
