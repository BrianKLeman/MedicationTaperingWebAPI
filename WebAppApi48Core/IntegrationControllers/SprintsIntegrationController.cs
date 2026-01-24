using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using WebAppApi48Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebAppApi48Core.IntegrationControllers.HackNPlan.HackNPlanModels;
using WebAppApi48Core.IntegrationControllers.HackNPlan;

namespace WebAppApi48.Integration.Controllers
{
    [Authorize]
    public class SprintsIntegrationController : ControllerBase
    {
        public SprintsIntegrationController(IAuthService authService, IConnectionStringProvider connectionStringProvider)
        {
            this.authService = authService;
            this.repo = new ODataRepository<Sprint>(connectionStringProvider);
        }

        private IAuthService authService;
        private ODataRepository<Sprint> repo = null;

        private bool SprintExists(int key)
        {
            var personID = this.authService.GetPersonCode(HttpContext);  
            return repo.Get(personID).Any(p => p.Id == key);
        }

        [Route("Api/Integration/Sprints/CreateBoard")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]Board board)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);
            var personID = this.authService.GetPersonCode(HttpContext);


            var result = await repo.Insert(personID, board.ToNewSprint( personID));
            return Created();
        }

        [Route("Api/Integration/Sprints/UpdateBoard")]
        [HttpPost]
        public async Task<IActionResult> UpdateBoard([FromBody] Board board)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);
            var personID = this.authService.GetPersonCode(HttpContext);

            var existing = repo.Get(personID).FirstOrDefault(s => s.BoardId == board.BoardId);
            if (existing == null) {
                await repo.Insert(personID, board.ToNewSprint(personID));
            }
            else
            {
                await repo.Update(personID, board.ToSprint(personID, existing.Id));                
            }
            return Created();
        }

        [Route("Api/Integration/Sprints/DeleteBoard")]
        [HttpPost]
        public async Task<IActionResult> DeleteBoard([FromBody] Board board)
        {
            if(ModelState.IsValid == false)
                return BadRequest(ModelState);
            var personID = this.authService.GetPersonCode(HttpContext);

            var existing = repo.Get(personID).FirstOrDefault(s => s.BoardId == board.BoardId);
            if (existing == null)
            {
                return NotFound("Board Not found");
            }
            var result = await repo.Delete(personID,  existing);
            return Created();
        }
    }
}