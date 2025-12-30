using Data.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAppApi48Core.Services;

namespace WebAppApi48Core.Controllers
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

    [Route("Api/Notes")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Produces("application/json")]
    public class NotesController : ControllerBase
    {        
        public NotesController(IAuthService authService, INotesDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
        }

        private IAuthService authService;
        private INotesDataAccess dataAccess;
        
        private IActionResult Get(DateTime? fromDate, DateTime? toDate)
        {

            var personID = this.authService.GetPersonCode(HttpContext);
            var results = dataAccess.GetNotes(personID, fromDate.Value, toDate.Value, personID > 0);
            return base.Ok(results);
        }


        [HttpGet]
        public IActionResult Get( string tableName, long entityID, DateTime? fromDate, DateTime? toDate)
        {
            if(fromDate.HasValue || toDate.HasValue) 
                return Get(fromDate, toDate);

            var personID = this.authService.GetPersonCode(HttpContext);
            bool includePersonal = personID > 0;
            

            return base.Ok(dataAccess.GetNotes(personID, tableName, entityID, includePersonal));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Note body)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);

            return base.Ok(dataAccess.InsertNote(personID, body.dateTime, body.NoteText, body.BehaviorChange, body.DisplayAsHTML, body.EntityID, body.TableName));
        }

        /// <summary>
        /// Delete the note by id.
        /// </summary>
        /// <param name="noteID"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{noteID:long}")]
        public IActionResult Delete([FromRoute] long noteID)
        {
            var personID = this.authService.GetPersonCode(HttpContext);
            return base.Ok(dataAccess.DeleteNote(personID, noteID));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Note body)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);
            var personID = this.authService.GetPersonCode(HttpContext);
            return base.Ok(dataAccess.UpdateNote(personID, body.dateTime, body.NoteText, body.BehaviorChange, body.NoteID, body.DisplayAsHTML));
        }

    }
}
