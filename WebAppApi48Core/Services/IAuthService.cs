


namespace WebAppApi48Core.Services
{

    public interface IAuthService
    {
        long VerifyCredentials(string userID, string password);
        long CheckToken(string token);
        string CreateToken(long personID, out string UserID, out string Token);
        long GetPersonCode(HttpContext context);
    }
}