
using Microsoft.AspNetCore.Mvc;
namespace WebAppApi48Core.Controllers
{
   
  

    [Route("/")]
    public class HomeController : ControllerBase
    {        
        public HomeController()
        {

        }

        [HttpGet()]
        public IActionResult Get()
        {
            return Redirect("/swagger");          
        }        
    }
}
