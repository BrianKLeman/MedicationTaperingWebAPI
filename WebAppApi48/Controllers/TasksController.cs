using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using WebAppApi48.Services;
using System.Linq;
using Resolver = System.Web.Mvc.DependencyResolver;
using DataAccessLayer.Repository;

namespace WebAppApi48.Controllers
{    
    public class TasksGroupsViewModel
    {
        public Tasks Task { get; set; }
        public IEnumerable<Groups> Groups { get; set; }
        public IEnumerable<Sprint> Sprints { get; set; }
    }

    [RoutePrefix("Api/Tasks")]
    public class TasksController : ApiController
    {        
        public TasksController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(ITasksDataAccess)) as ITasksDataAccess;
            this.groupsDataAccess = Resolver.Current.GetService(typeof(IGroupsDataAccess)) as IGroupsDataAccess;
            this.tasksLinksDataAccess = Resolver.Current.GetService(typeof(ITableTasksLinksDataAccess)) as ITableTasksLinksDataAccess;
            this.odataDataAccess = new ODataRepository<Sprint>();
        }

        private IAuthService authService;
        private ITasksDataAccess dataAccess;
        private IGroupsDataAccess groupsDataAccess;
        private ODataRepository<Sprint> odataDataAccess;
        private ITableTasksLinksDataAccess tasksLinksDataAccess;
        public IHttpActionResult Get()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            return base.Ok(dataAccess.GetTasks(personID, includePersonal));
        }
        
        public IHttpActionResult Get(string tableName, long entityID)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            return base.Ok(dataAccess.GetTasks(personID, tableName, entityID, includePersonal));
        }

        [HttpGet]
        [Route("TasksWithExtras")]
        public IHttpActionResult TasksWithExtras()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            var tasks = dataAccess.GetTasks(personID, includePersonal).ToList();
            var groupLinks = this.tasksLinksDataAccess.Select(personID, tasks.Select(x => x.Id).ToArray(), "GROUPS");
            var sprintLinks = this.tasksLinksDataAccess.Select(personID, tasks.Select(x => x.Id).ToArray(), "SPRINTS");
            var groups = this.groupsDataAccess.GetGroups(personID);
            var sprints = this.odataDataAccess.Get(personID).ToList();
            var vms = new List<TasksGroupsViewModel>();
            foreach (var t in tasks)
            {
                var linkIDs = groupLinks.Where(gl => gl.TaskID == t.Id).Select(gl => gl.EntityID);
                var sprintIDs = sprintLinks.Where(sl => sl.TaskID == t.Id).Select(sl => sl.EntityID);
                vms.Add(new TasksGroupsViewModel
                {
                    Task = t,
                    Groups = groups.Where(x => linkIDs.Contains(x.Id)),
                    Sprints = sprints.Where(x => sprintIDs.Contains(x.Id))
                }
                );
            }
            return base.Ok(vms);
        }

        [HttpGet]
        [Route("TasksWithExtras")]
        public IHttpActionResult TasksWithExtras(string tableName, long entityID)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            bool includePersonal = personID > 0;
            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            var tasks = dataAccess.GetTasks(personID, tableName, entityID, includePersonal).ToList();
            var groupLinks = this.tasksLinksDataAccess.Select(personID, tasks.Select(x => x.Id).ToArray(), "GROUPS");
            var sprintLinks = this.tasksLinksDataAccess.Select(personID, tasks.Select(x => x.Id).ToArray(), "SPRINTS");
            var groups = this.groupsDataAccess.GetGroups(personID);
            var sprints = this.odataDataAccess.Get(personID).ToList();
            var vms = new List<TasksGroupsViewModel>();
            foreach(var t in tasks)
            {
                var linkIDs = groupLinks.Where(gl => gl.TaskID == t.Id).Select(gl => gl.EntityID);
                var sprintIDs = sprintLinks.Where(sl => sl.TaskID == t.Id).Select(sl => sl.EntityID);
                vms.Add(new TasksGroupsViewModel
                {
                    Task = t,
                    Groups = groups.Where(x => linkIDs.Contains(x.Id)),
                    Sprints = sprints.Where( x => sprintIDs.Contains(x.Id))
                }
                );
            }
            return base.Ok(vms);
        }

        
        public IHttpActionResult Put([FromBody] Tasks body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            return base.Ok(dataAccess.UpdateTask(personID, body));
        }

        public IHttpActionResult Post([FromBody] Tasks body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            if (personID < 1)
                return Unauthorized();

            return base.Ok<long>(dataAccess.CreateTask(personID, body));
        }

        public IHttpActionResult Delete([FromBody] Tasks body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            if (personID < 1)
                return Unauthorized();

            return base.Ok(dataAccess.DeleteTask(personID, body));
        }

    }
}
