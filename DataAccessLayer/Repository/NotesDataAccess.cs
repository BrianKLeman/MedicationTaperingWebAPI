using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class NotesDataAccess : DataAccessBase, INotesDataAccess
    {       
        public IEnumerable<Notes> GetNotes(long personID, DateTime fromDate, DateTime toDate)
        {
            using (var c = NewDataConnection())
            {
                if(personID > -1)
                {
                    var notes = from n in c.GetTable<Notes>()
                            where n.PersonID == personID && fromDate < n.RecordedDate && toDate > n.RecordedDate
                            select n;
                    return notes.ToList();
                }
                else
                {
                    return new Notes[0];
                }
                
            }                
        }

        public long InsertNote(long personID, DateTime date, string note)
        {
            if(personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    return c.Insert<Notes>(new Notes() { PersonID = personID, RecordedDate = date, Text = note, UpdatedUser = "BKL" });
                }
            }
            return -1;            
        }

        public long DeleteNote(long personID, long noteID)
        {
            if(personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    return c.Delete<Notes>(new Notes { NoteID = noteID, PersonID = personID });
                }
            }

            return -1;
        }
    }
}