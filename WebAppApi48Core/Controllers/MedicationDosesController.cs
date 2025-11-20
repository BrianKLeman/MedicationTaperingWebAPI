using DataAccessLayer;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebAppApi48Core.Services;

namespace WebAppApi48Core.Controllers
{
    public class MedDose
    {
        [Required]
        public DateTime consumedDateTime { get; set; }

        [Required]
        public decimal doseMg { get; set; }

        [Required]

        public long PrescriptionID { get; set; }
    }

    public class Report
    {
        public long Id { get; set; }
        public DateTime DateTimeConsumed { get; set; }
        public string Name { get; set; }
        public decimal DoseTakenMG { get; set; }
        public decimal DoseMG { get; set; }

        public decimal HalfLifeHrs { get; set; }
        public long PrescriptionID { get; set; }
    }

    [Route("Api/MedicationDoses")]
    public class MedicationDosesController : ControllerBase
    {

        public MedicationDosesController(IAuthService authService, IMedicationDataAccess dataAccess, IPrescriptionDataAccess prescriptionDataAccess)
        {
            this.authService = authService;
            this.dataAccess = dataAccess;
            this.prescriptions = prescriptionDataAccess;
        }

        private IAuthService authService;
        private IMedicationDataAccess dataAccess;
        private IPrescriptionDataAccess prescriptions;

        [HttpGet]
        public IEnumerable<Report> Get()
        {
            var personID = this.authService.GetPersonCode(HttpContext);            

            var meds = dataAccess.GetMedication(personID);
            var pres = prescriptions.GetPrescriptions(personID);

            return from m in meds
                   join p in pres on m.PrescriptionId equals p.Id
                   orderby m.DateTimeConsumed descending
                   select new Report
                   {
                       Id = m.Id,
                       DateTimeConsumed = m.DateTimeConsumed,
                       Name = p.Name,
                       DoseTakenMG = m.DoseTakenMG,
                       DoseMG = p.DoseMG,
                       HalfLifeHrs = p.AverageHalfLifeHours ?? 0,
                       PrescriptionID = p.Id
                   };
        }

        [HttpDelete]
        [Route("{medicationId:int}")]
        public IActionResult Delete([FromRoute] [Required]int medicationId)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            // Get person ID for user and password.
            var personID = this.authService.GetPersonCode(HttpContext);

            dataAccess.Delete(personID,medicationId);
            return base.Ok();
        }

        [HttpPost]
        public IActionResult Post([FromBody][Required] MedDose dose)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var personID = this.authService.GetPersonCode(HttpContext);

            dataAccess.InsertMedication(personID, dose.consumedDateTime, dose.PrescriptionID, dose.doseMg);
            return base.Ok();
        }
    }
}