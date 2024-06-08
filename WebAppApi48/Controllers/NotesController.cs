using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAppApi48.Services;

namespace WebAppApi48.Controllers
{
    public class NotesSearchRequest
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }

    public class NotesController : ApiController
    {

        
        public NotesController()
        {
            this.authService = new AuthService();
        }

        private IAuthService authService;

        [HttpPost()]
        public IEnumerable<Notes> Post([FromBody] NotesSearchRequest request)
        {
            var personID = this.authService.VerifyCredentials(Request);
            
            return DataAccess.GetNotes(personID, request.FromDate, request.ToDate);
        }
    }
}
