
using Data.Services.Interfaces.IModels;

namespace Data.Services.Interfaces
{
    public interface INotesDataAccess
    {
        IEnumerable<INote> GetNotes(long personID, DateTime fromDate, DateTime toDate, bool includePersonal);

        IEnumerable<INote> GetNotes(long personID, string tableName, long entityID, bool includePersonal);

        long InsertNote(long personID, DateTime date, string note, bool behaviourChangeNeeded, bool displayAsHTML, long entityID, string tableName);

        long DeleteNote(long personID, long noteID);

        long UpdateNote(long personID, DateTime date, string note, bool behaviorChange, long noteID, bool displayAsHTML);
        
    }
}