using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;
using Data.Services.Interfaces;
using Data.Services.Interfaces.IModels;

namespace DataAccessLayer
{
    public class NotesDataAccess : DataAccessBase, Data.Services.Interfaces.INotesDataAccess
    {
        public NotesDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }
        public IEnumerable<INote> GetNotes(long personID, DateTime fromDate, DateTime toDate, bool includePersonal)
        {
            using (var c = NewDataConnection())
            {
                if(personID > -1)
                {
                    // Force from date and to date to be beginning and end of day.
                    fromDate = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, 0, 0, 0);
                    toDate = new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59, 999);

                    var notes = from n in c.GetTable<Notes>()
                            where n.PersonId == personID && fromDate < n.RecordedDate && toDate > n.RecordedDate && (includePersonal || n.Personal != 1)
                                orderby n.RecordedDate descending
                            select n;
                    return notes.ToList();
                }
                else
                {
                    return new Notes[0];
                }
                
            }                
        }

        public IEnumerable<INote> GetNotes(long personID, string tableName, long entityID, bool includePersonal)
        {
            using (var c = NewDataConnection())
            {
                if (personID > -1)
                {
                    var notes = from n in c.GetTable<Notes>()
                                where n.PersonId == personID && (includePersonal || n.Personal != 1)
                                join link in c.GetTable<TableNotesLinks>() on n.Id equals link.NotesID
                                where link.EntityID == entityID && link.Table == tableName
                                orderby n.RecordedDate descending
                                select n;
                    return notes.ToList();
                }
                else
                {
                    return new Notes[0];
                }

            }
        }

        public long InsertNote(long personID, DateTime date, string note, bool behaviourChangeNeeded, bool displayAsHTML, long entityID, string tableName)
        {
            if(personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    var n = new Notes()
                    {
                        PersonId = (uint)personID,
                        RecordedDate = date,
                        Text = note,
                        UpdatedUser = "BKL",
                        BehaviorChange = behaviourChangeNeeded ? 1 : 0,
                        DisplayAsHTML = displayAsHTML,
                        Personal = 1 // Put as personal by default now.
                    };
                    var result = c.Insert<Notes>( n);

                    var newNote = from nn in c.GetTable<Notes>()
                                  where nn.Text == n.Text && nn.RecordedDate == n.RecordedDate && nn.PersonId == n.PersonId
                                  select nn.Id;

                    var noteID = newNote.FirstOrDefault();

                    if(noteID > 0 && !string.IsNullOrWhiteSpace(tableName))
                    {
                        result = c.Insert<TableNotesLinks>(
                        new TableNotesLinks()
                        {
                            PersonId = (uint)personID,
                            CreatedDate = DateTime.Now,
                            NotesID = noteID,
                            CreatedBy = "BKL",
                            EntityID = entityID,
                            Table = tableName
                        });

                    }
                    

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
                    return c.Delete<Notes>(new Notes { Id = (uint)noteID, PersonId = (uint)personID });
                }
            }

            return -1;
        }

        public long UpdateNote(long personID, DateTime date, string note, bool behaviourChangeNeeded, long noteID, bool displayAsHTML)
        {
            if (personID != PersonDataAccess.INVALID_PERSON_CODE)
            {
                using (var c = NewDataConnection())
                {
                    // check note belongs to person first.
                    var n = from a in c.GetTable<Notes>()
                            where a.Id == noteID && a.PersonId == personID
                            select a;

                    // Update and Save Note
                    if(n != null && n.Count() == 1)
                    {
                        var n0 = n.First();
                        n0.RecordedDate = date;
                        n0.Text = note;
                        n0.BehaviorChange = behaviourChangeNeeded ? 1 : 0;
                        n0.DisplayAsHTML = displayAsHTML;
                        return c.Update<Notes>(n0);

                    }

                }
            }
            return -1;
        }
    }
}