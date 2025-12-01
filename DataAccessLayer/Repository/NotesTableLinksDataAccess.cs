using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class NoteLinksDataAccess : DataAccessBase, ITableNotesLinksDataAccess
    {
        public NoteLinksDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }

        public long Insert(long personID, long[] noteIDs, string table_name, long entity_id)
        {
            var result = -1;
            if(personID > 0)
            {
                using (var c = NewDataConnection())
                {
                    foreach (var id in noteIDs)
                    {
                        result = c.Insert<TableNotesLinks>(new TableNotesLinks() { PersonId = (uint)personID, CreatedDate = DateTime.Now, NotesID = id, CreatedBy = "BKL", EntityID = entity_id, Table = table_name });
                        
                    }
                }
            }
            return -1;            
        }

       
    }
}