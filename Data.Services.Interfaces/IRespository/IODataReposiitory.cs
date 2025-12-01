using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces.IRespository
{
    public interface IODataRepository<T>
    {
        public IQueryable<T> Get(long personCode);

        public Task<int> Update(long personCode, T record);

    }
}
