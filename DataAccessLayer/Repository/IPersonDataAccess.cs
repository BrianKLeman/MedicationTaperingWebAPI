namespace DataAccessLayer.Repository
{
    public interface IPersonDataAccess
    {
        long AddToken(long personID, string token);
        long CheckToken(string token);
        long GetPersonID(string username, string password);
        long GetPersonIDForReadOnlyAccess(string username);
        string GetPassword(string username, string password);
    }
}
