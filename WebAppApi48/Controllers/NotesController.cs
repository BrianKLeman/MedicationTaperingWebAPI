using DataAccessLayer;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using WebAppApi48.Services;

using Resolver = System.Web.Mvc.DependencyResolver;
namespace WebAppApi48.Controllers
{
    public class NotesSearchRequest
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }

    public class Note
    {
        [Required]
        public DateTime dateTime { get; set; }

        [Required]
        public string NoteText { get; set; }
    }

    [RoutePrefix("Api/Notes")]
    public class NotesController : ApiController
    {        
        public NotesController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(INotesDataAccess)) as INotesDataAccess;
        }

        private IAuthService authService;
        private INotesDataAccess dataAccess;

        [HttpPost()]
        public IHttpActionResult Post([FromBody] NotesSearchRequest request)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            
            return base.Ok(dataAccess.GetNotes(personID, request.FromDate, request.ToDate));
        }

        [HttpPost]
        [Route("Add")]
        public IHttpActionResult Add([FromBody] Note body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            return base.Ok(dataAccess.InsertNote(personID, body.dateTime, body.NoteText));
        }

        [HttpPost]
        [HttpDelete]
        [Route("Delete/{noteID:long}")]
        public IHttpActionResult Delete([FromUri] long noteID)
        {
            var personID = this.authService.VerifyCredentials(Request);
            return base.Ok(dataAccess.DeleteNote(personID, noteID));
        }

    }
}
