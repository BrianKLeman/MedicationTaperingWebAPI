using DataAccessLayer.Models;
using System;
using LinqToDB;
using DataAccessLayer.Repository;

namespace DataAccessLayer
{
    public class NoteLinksDataAccess : DataAccessBase, ITableNotesLinksDataAccess
    {
        public NoteLinksDataAccess(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider) { }

        public long Insert(uint personID, long[] noteIDs, string table_name, long entity_id)
        {
            long result = -1;
            using (var c = NewDataConnection())
            {
                foreach (var id in noteIDs)
                {
                    result = c.Insert<TableNotesLinks>(new TableNotesLinks() { PersonId = personID, CreatedDate = DateTime.Now, NotesID = id, CreatedBy = "BKL", EntityID = entity_id, Table = table_name });
                        
                }
            }

            return result;       
        }
    }
}