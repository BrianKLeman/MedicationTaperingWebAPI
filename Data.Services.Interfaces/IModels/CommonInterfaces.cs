using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces.IModels
{
    public interface IPersonID
    {
        uint PersonId { get; set; }
    }

    public interface IId
    {
        uint Id { get; set; }
    }
}
