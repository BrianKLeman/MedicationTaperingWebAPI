﻿using DataAccessLayer.Models;
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

        public long InsertNote(long personID, DateTime date, string note, bool behaviourChangeNeeded)
        {
            if(personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    return c.Insert<Notes>(new Notes() { PersonID = personID, RecordedDate = date, Text = note, UpdatedUser = "BKL",  BehaviorChange = behaviourChangeNeeded ? 1 : 0});
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

        public long UpdateNote(long personID, DateTime date, string note, bool behaviourChangeNeeded, long noteID)
        {
            if (personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    // check note belongs to person first.
                    var n = from a in c.GetTable<Notes>()
                            where a.NoteID == noteID && a.PersonID == personID
                            select a;

                    // Update and Save Note
                    if(n != null && n.Count() == 1)
                    {
                        var n0 = n.First();
                        n0.RecordedDate = date;
                        n0.Text = note;
                        n0.BehaviorChange = behaviourChangeNeeded ? 1 : 0;
                        return c.Update<Notes>(n0);

                    }

                }
            }
            return -1;
        }
    }
}