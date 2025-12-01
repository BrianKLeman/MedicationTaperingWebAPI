using DataAccessLayer.Models;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Services.Interfaces.IRespository;
using Data.Services.Interfaces.IModels;

namespace DataAccessLayer.Repository
{
    public class ODataRepository<T> : DataAccessBase, IODataRepository<T>, IDisposable where T : class, IPersonID, IId
    {
        public ODataRepository(IConnectionStringProvider connectionStringProvider)
            : base(connectionStringProvider)
        {
            this.Connection = this.NewDataConnection();
        }

        private DataConnection Connection;
        public IQueryable<T> Get(long personCode)
        {
            return this.Connection.GetTable<T>().Where(x => x.PersonId == personCode);            
        }

        public Task<int> Update(long personCode, T record)
        {
            var exists = Connection.GetTable<T>().Where(x => x.PersonId == personCode && x.Id == record.Id)?.FirstOrDefault();
            if(exists != null)
                return Connection.UpdateAsync<T>(record);

            return new Task<int>( () => -1); // Fake task.
        }

        public void Dispose()
        {
            Connection.Dispose();
            Connection = null;
        }
    }
}
