
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAppApi48Core.Services;
namespace WebAppApi48Core.Controllers
{
   
    public class AuthToken
    {
        public string UserID { get; set; }
        public string Token { get; set; }
    }

    [Route("Api/Auth")]
    [Authorize]
    public class AuthController : ControllerBase
    {        
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
    }

        private IAuthService authService;

        [HttpGet()]
        [Route("Token")]
        public IActionResult Token()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);
            var personCode = this.authService.GetPersonCode(HttpContext);
            var result = this.authService.CreateToken(personCode, out string UserID, out string Token);

            return Ok(new AuthToken() { UserID = UserID, Token = Token });            
        }        
    }
}
