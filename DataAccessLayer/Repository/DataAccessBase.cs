using MySql.Data.MySqlClient;
using LinqToDB.DataProvider.MySql;
using LinqToDB.Data;

namespace DataAccessLayer.Repository
{
    public abstract class DataAccessBase
    {
        protected DataConnection NewDataConnection()
        {
            var cBuilder = new MySqlConnectionStringBuilder();
            cBuilder.Server = DatalayerConfig.GetHost();
            cBuilder.Port = DatalayerConfig.GetPort();
            cBuilder.UserID = DatalayerConfig.GetUserName();
            cBuilder.Password = DatalayerConfig.GetPassword();
            cBuilder.Database = DatalayerConfig.GetDataBaseName();

            return MySqlTools.CreateDataConnection(cBuilder.ConnectionString);
        }
    }
}
