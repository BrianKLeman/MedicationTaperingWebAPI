using DataAccessLayer;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using WebAppApi48.Services;

using Resolver = System.Web.Mvc.DependencyResolver;
namespace WebAppApi48.Controllers
{
   
    public class AuthToken
    {
        public string UserID { get; set; }
        public string Token { get; set; }
    }

    [RoutePrefix("Api/Auth")]
    public class AuthController : ApiController
    {        
        public AuthController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
        }

        private IAuthService authService;

        [HttpGet()]
        [Route("Token")]
        public IHttpActionResult Token()
        {
            if (ModelState.IsValid == false)
                return base.BadRequest(ModelState);

            var result = this.authService.CreateToken(Request, out string UserID, out string Token);

            return Ok(new AuthToken() { UserID = UserID, Token = Token });            
        }        
    }
}
