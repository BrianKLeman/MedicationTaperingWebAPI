using DataAccessLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAppApi48Core.Services;

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

    [Route("Api/NoteLinks")]
    [Authorize]
    public class NoteLinksController : ControllerBase
    {
        public NoteLinksController(IAuthService authService, ITableNotesLinksDataAccess dataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
        }

        private IAuthService authService;
        private ITableNotesLinksDataAccess dataAccess;

        [HttpPost]
        public IActionResult Post([FromBody] NoteLinks requestModel)
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);
            return Ok(dataAccess.Insert(personID, requestModel.NoteIDs, requestModel.Table, requestModel.EntityID));
        }

    }
}