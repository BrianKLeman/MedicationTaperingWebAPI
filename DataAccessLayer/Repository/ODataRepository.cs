using DataAccessLayer.Models;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class ODataRepository<T> : DataAccessBase, IDisposable where T : class, IPersonID
    {
        public ODataRepository()
        {
            this.Connection = this.NewDataConnection();
        }

        private DataConnection Connection;
        public IQueryable<T> Get(long personCode)
        {
            return this.Connection.GetTable<T>().Where(x => x.PersonID == personCode);
            
        }

        public void Dispose()
        {
            Connection.Dispose();
            Connection = null;
        }
    }
}
