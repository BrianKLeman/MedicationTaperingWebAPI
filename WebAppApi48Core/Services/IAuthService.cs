


namespace WebAppApi48Core.Services
{

    public interface IAuthService
    {
        uint VerifyCredentials(string userID, string password);
        uint CheckToken(string token);
        string CreateToken(long personID, out string UserID, out string Token);
        uint GetPersonCode(HttpContext context);
    }
}