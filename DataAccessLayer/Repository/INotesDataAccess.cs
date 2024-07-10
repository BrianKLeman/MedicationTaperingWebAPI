using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface INotesDataAccess
    {
        IEnumerable<Notes> GetNotes(long personID, DateTime fromDate, DateTime toDate);

        long InsertNote(long personID, DateTime date, string note);

        long DeleteNote(long personID, long noteID);
        
    }
}