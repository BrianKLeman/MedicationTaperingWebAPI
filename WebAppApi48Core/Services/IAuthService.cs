


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
        long VerifyCredentials(HttpRequest request);
        long VerifyReadOnlyCredentials(HttpRequest request);
        string CreateToken(HttpRequest request, out string UserID, out string Token);
    }
}