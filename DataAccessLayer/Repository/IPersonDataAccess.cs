namespace DataAccessLayer.Repository
{
    public interface IPersonDataAccess
    {
        uint AddToken(long personID, string token);
        uint CheckToken(string token);
        uint GetPersonID(string username, string password);
        uint GetPersonIDForReadOnlyAccess(string username);
        string GetPassword(string username, string password);

        string GetUserID(long personID);
    }
}
