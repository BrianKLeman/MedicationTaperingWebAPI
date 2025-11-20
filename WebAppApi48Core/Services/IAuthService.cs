


namespace WebAppApi48Core.Services
{
public static class HeadersConstants
    {
        public const string UserID = nameof(UserID);
        public const string Password = nameof(Password);
        public const string AuthToken = "Auth-Token";
        public const string ContentType = "Content-Type";
    }

    public interface IAuthService
    {
        long VerifyCredentials(string userID, string password);
        long VerifyCredentials(HttpRequest request);
        long CheckToken(string token);
        long VerifyReadOnlyCredentials(HttpRequest request);
        string CreateToken(HttpRequest request, out string UserID, out string Token);

        long GetPersonCode(HttpContext context);
    }
}