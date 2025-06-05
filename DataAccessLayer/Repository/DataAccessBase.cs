using MySql.Data.MySqlClient;
using LinqToDB.DataProvider.MySql;
using LinqToDB.Data;

namespace DataAccessLayer.Repository
{
    public interface IConnectionStringProvider
    {
        string GetConnectionString();
    }
    public abstract class DataAccessBase
    {
        IConnectionStringProvider _connectionStringProvider;
        public DataAccessBase(IConnectionStringProvider connectionStringProvider)
        {
            _connectionStringProvider = connectionStringProvider;
        }
        protected DataConnection NewDataConnection()
        {
            
            return MySqlTools.CreateDataConnection(_connectionStringProvider.GetConnectionString());
        }
    }
}
