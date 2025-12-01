using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces.IModels
{
    public interface INote
    {        
        public uint Id { get; set; }

        public uint PersonId { get; set; }

        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedUser { get; set; }

        public string UpdatedUser { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public DateTime? RecordedDate { get; set; }

        public int BehaviorChange { get; set; }

        public bool DisplayAsHTML { get; set; }

        public int Personal { get; set; }
     
    }
}
