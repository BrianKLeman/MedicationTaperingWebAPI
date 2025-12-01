using DataAccessLayer.Repository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using WebAppApi48Core.Services;

/// <summary>
/// Based on Code from Claude.ai for prompt: how do i setup basic authentication with username and password in .net 9 asp.net core
/// </summary>
public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{

    public const string PERSON_CODE_CLAIM = "PersonID";
    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        IAuthService authService)
        : base(options, logger, encoder)
    {
        this.authService = authService;
    }

    private readonly IAuthService authService;
    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.ContainsKey("Authorization"))
            return AuthenticateResult.Fail("Missing Authorization Header");

        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes);
            var parts = new string[0];
            
            if (credentials.Contains(':'))
                parts = credentials.Split(':', 2);

            long personID = PersonDataAccess.INVALID_PERSON_CODE;
            // Validate credentials (replace with your actual validation logic)
            if ((parts.Length == 2 && IsValidUser(parts[0], parts[1], out personID))
                || IsValidToken(credentials, out personID))
            {
                var claims = new[] {                    
                    new Claim(PERSON_CODE_CLAIM, personID.ToString())
                };
                var identity = new ClaimsIdentity(claims, Scheme.Name);
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, Scheme.Name);

                return AuthenticateResult.Success(ticket);
            }
            else
            {
                return AuthenticateResult.Fail("Invalid Username or Password");
            }
        }
        catch
        {
            return AuthenticateResult.Fail("Invalid Authorization Header");
        }
    }

    private bool IsValidUser(string username, string password, out long personID)
    {
        personID = authService.VerifyCredentials(username, password);
        return personID > 0;
    }

    private bool IsValidToken(string token, out long personID)
    {
        personID = authService.CheckToken(token);
        return personID > 0;
    }
}