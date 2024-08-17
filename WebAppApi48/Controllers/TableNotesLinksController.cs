using DataAccessLayer;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using WebAppApi48.Attributes;
using WebAppApi48.Services;
using Resolver = System.Web.Mvc.DependencyResolver;

namespace WebAppApi48.Controllers
{
    
    public class NoteLinks
    {
        [Required]
        public string Table { get; set; }

        [Required]
        public long EntityID { get; set; }

        [Required]
        public long[] NoteIDs { get; set; }
    }

    [RoutePrefix("Api/NoteLinks")]
    public class NoteLinksController : ApiController
    {
        public NoteLinksController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(ITableNotesLinksDataAccess)) as ITableNotesLinksDataAccess;
        }

        private IAuthService authService;
        private ITableNotesLinksDataAccess dataAccess;       
        
        [HttpPost]
        public IHttpActionResult AddLinks([FromBody] NoteLinks requestModel)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            return Ok(dataAccess.Insert(personID, requestModel.NoteIDs, requestModel.Table, requestModel.EntityID));
        }

    }
}