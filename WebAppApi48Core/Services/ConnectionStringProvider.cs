using DataAccessLayer.Repository;

namespace WebAppApi48Core.Services
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {

        public ConnectionStringProvider(string connectString) { 
            this.connectString = connectString;
        }

        private string connectString = string.Empty;
        public string GetConnectionString()
        {
            
            return (string)connectString.Clone();
        }
    }
}
