using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAppApi48.Controllers
{
    public class NotesSearchRequest
    {
        public long PersonID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Password { get; set; }
    }

    public class NotesController : ApiController
    {
        public NotesController()
        {

        }

        [HttpPost()]
        public IEnumerable<Notes> Post([FromBody] NotesSearchRequest request)
        {
            if (request.Password != DataAccess.GetPassword(request.PersonID))
                return new Notes[0];

            return DataAccess.GetNotes(request.PersonID, request.FromDate, request.ToDate);
        }
    }
}
