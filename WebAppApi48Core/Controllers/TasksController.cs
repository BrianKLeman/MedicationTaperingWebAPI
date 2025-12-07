using DataAccessLayer;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;

namespace WebAppApi48Core.Controllers
{    
    public class TasksGroupsViewModel
    {
        public Tasks Task { get; set; }
        public IEnumerable<Groups> Groups { get; set; }
        public IEnumerable<Sprint> Sprints { get; set; }
        public IEnumerable<Feature> Features { get; set; }
    }

    [Route("Api/Tasks")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController]
    [Produces("application/json")]
    public class TasksController : ControllerBase
    {        
        public TasksController(IFeaturesDataAccess featuresDataAccess, IAuthService authService, ITasksDataAccess dataAccess, IGroupsDataAccess groupsDataAccess, ITableTasksLinksDataAccess tasksDataAccess, IConnectionStringProvider connectionStringProvider)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
            this.groupsDataAccess = groupsDataAccess;
            this.tasksLinksDataAccess = tasksDataAccess;
            this.odataDataAccess = new ODataRepository<Sprint>(connectionStringProvider);
            this.featuresDataAccess = featuresDataAccess;
        }

        private IAuthService authService;
        private ITasksDataAccess dataAccess;
        private IGroupsDataAccess groupsDataAccess;
        private ODataRepository<Sprint> odataDataAccess;
        private ITableTasksLinksDataAccess tasksLinksDataAccess;
        private IFeaturesDataAccess featuresDataAccess;

        /// <summary>
        /// Gets all tasks for the person. If tableName and entityID are provided, gets only tasks linked to that entity.
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="entityID"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<Tasks>), StatusCodes.Status200OK)]
        public IActionResult Get(string tableName, long entityID)
        {           

            var personID = this.authService.GetPersonCode(HttpContext);

            if(tableName == null)
                return base.Ok(dataAccess.GetTasks(personID, true));
            else
                return base.Ok(dataAccess.GetTasks(personID, tableName, entityID, true));
        }

       
        private IActionResult TasksWithExtras()
        {           

            var personID = this.authService.GetPersonCode(HttpContext);

            var tasks = dataAccess.GetTasks(personID, true).ToList();

            var taskIDs = tasks.Select(x => x.Id).ToArray();
            var featureLinks = this.tasksLinksDataAccess.Select(personID, taskIDs, "FEATURES");
            var groupLinks = this.tasksLinksDataAccess.Select(personID, taskIDs, "GROUPS");
            var sprintLinks = this.tasksLinksDataAccess.Select(personID, taskIDs, "SPRINTS");
            var groups = this.groupsDataAccess.GetGroups(personID);
            var sprints = this.odataDataAccess.Get(personID).ToList();
            var features = this.featuresDataAccess.GetFeatures(personID, false);
            var vms = new List<TasksGroupsViewModel>();
            foreach (var t in tasks)
            {
                var linkIDs = groupLinks.Where(gl => gl.TaskID == t.Id).Select(gl => gl.EntityID);
                var sprintIDs = sprintLinks.Where(sl => sl.TaskID == t.Id).Select(sl => sl.EntityID);
                var featureIDs = featureLinks.Where(sl => sl.TaskID == t.Id).Select(sl => sl.EntityID);
                vms.Add(new TasksGroupsViewModel
                {
                    Task = t,
                    Groups = groups.Where(x => linkIDs.Contains(x.Id)),
                    Sprints = sprints.Where(x => sprintIDs.Contains(x.Id)),
                    Features = features.Where( x => featureIDs.Contains(x.Id ))
                }
                );
            }
            return base.Ok(vms);
        }

        [HttpGet]
        [Route("TasksWithExtras")]
        [ProducesResponseType( typeof(IEnumerable<TasksGroupsViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult TasksWithExtras(string tableName, long entityID)
        {
            if (tableName == null)
                return TasksWithExtras();

            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);
            bool includePersonal = true;
            

            var tasks = dataAccess.GetTasks(personID, tableName, entityID, includePersonal).ToList();
            var taskIDs = tasks.Select(x => x.Id).ToArray();
            var featureLinks = this.tasksLinksDataAccess.Select(personID, taskIDs , "FEATURES");
            var groupLinks = this.tasksLinksDataAccess.Select(personID, taskIDs, "GROUPS");
            var sprintLinks = this.tasksLinksDataAccess.Select(personID, taskIDs, "SPRINTS");
            var groups = this.groupsDataAccess.GetGroups(personID);
            var sprints = this.odataDataAccess.Get(personID).ToList();
            var features = this.featuresDataAccess.GetFeatures(personID, false).ToList();
            var vms = new List<TasksGroupsViewModel>();
            foreach(var t in tasks)
            {
                var linkIDs = groupLinks.Where(gl => gl.TaskID == t.Id).Select(gl => gl.EntityID);
                var sprintIDs = sprintLinks.Where(sl => sl.TaskID == t.Id).Select(sl => sl.EntityID);
                var featureIDs = featureLinks.Where(sl => sl.TaskID == t.Id).Select(sl => sl.EntityID);
                vms.Add(new TasksGroupsViewModel
                {
                    Task = t,
                    Groups = groups.Where(x => linkIDs.Contains(x.Id)),
                    Sprints = sprints.Where( x => sprintIDs.Contains(x.Id)),
                    Features = features.Where( x => featureIDs.Contains(x.Id))
                }
                );
            }
            return base.Ok(vms);
        }


        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Put([FromBody] Tasks body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);

            return base.Ok(dataAccess.UpdateTask(personID, body));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Tasks body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);

            return base.Ok(dataAccess.CreateTask(personID, body));
        }

        /// <summary>
        /// Deletes the task with id specified in the body.
        /// </summary>
        /// <param name="body">Task object to delete (must include id).</param>
        /// <returns>Deleted task confirmation</returns>
        [HttpDelete]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromBody] Tasks body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);   

            return base.Ok(dataAccess.DeleteTask(personID, body));
        }

    }
}
