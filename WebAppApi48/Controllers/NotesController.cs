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

        public bool BehaviorChange { get; set; } = false;

        public long NoteID { get; set; }

        public bool DisplayAsHTML { get; set; } = false;

        public string TableName { get; set; } = string.Empty;

        public long EntityID { get; set; } = -1;
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
        
        public IHttpActionResult Get(DateTime? fromDate, DateTime? toDate)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);
            var results = dataAccess.GetNotes(personID, fromDate.Value, toDate.Value);
            return base.Ok(results);
        }

       

        public IHttpActionResult Get( string tableName, long entityID)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            if (personID <= 0)
                personID = this.authService.VerifyReadOnlyCredentials(Request);

            return base.Ok(dataAccess.GetNotes(personID, tableName, entityID));
        }
        
        public IHttpActionResult Post([FromBody] Note body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            return base.Ok(dataAccess.InsertNote(personID, body.dateTime, body.NoteText, body.BehaviorChange, body.DisplayAsHTML, body.EntityID, body.TableName));
        }
        
        [Route("{noteID:long}")]
        public IHttpActionResult Delete([FromUri] long noteID)
        {
            var personID = this.authService.VerifyCredentials(Request);
            return base.Ok(dataAccess.DeleteNote(personID, noteID));
        }
        
        public IHttpActionResult Put([FromBody] Note body)
        {
            var personID = this.authService.VerifyCredentials(Request);
            return base.Ok(dataAccess.UpdateNote(personID, body.dateTime, body.NoteText, body.BehaviorChange, body.NoteID, body.DisplayAsHTML));
        }

    }
}
