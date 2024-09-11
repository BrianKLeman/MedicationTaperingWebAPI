using DataAccessLayer.Models;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface INotesDataAccess
    {
        IEnumerable<Notes> GetNotes(long personID, DateTime fromDate, DateTime toDate);

        IEnumerable<Notes> GetNotes(long personID, string tableName, long entityID);

        long InsertNote(long personID, DateTime date, string note, bool behaviourChangeNeeded, bool displayAsHTML, long entityID, string tableName);

        long DeleteNote(long personID, long noteID);

        long UpdateNote(long personID, DateTime date, string note, bool behaviorChange, long noteID, bool displayAsHTML);
        
    }
}