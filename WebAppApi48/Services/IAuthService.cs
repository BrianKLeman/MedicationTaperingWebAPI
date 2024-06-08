using System.Net.Http;
using System.Web;

namespace WebAppApi48.Services
{
    public static class HeadersConstants
    {
        public const string UserID = nameof(UserID);
        public const string Password = nameof(Password);
        public const string ContentType = "Content-Type";
    }

    public interface IAuthService
    {
        long VerifyCredentials(HttpRequestMessage request);
        long VerifyReadOnlyCredentials(HttpRequestMessage request);
    }
}