using DataAccessLayer;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Http;

namespace WebAppApi48.Controllers
{
    public class MedDose
    {
        [Required]
        public DateTime consumedDateTime { get; set; }

        [Required]
        public decimal doseMg { get; set; }

        [Required]
        public string Password { get; set; }
    }

    public class Report
    {
        public long MedicationID { get; set; }
        public DateTime DateTimeConsumed { get; set; }
        public string Name { get; set; }
        public decimal DoseTakenMG { get; set; }
        public decimal DoseMG { get; set; }

        public decimal HalfLifeHrs { get; set; }
    }

    [RoutePrefix("MedicationDoses")]
    [Route("{action=History}")]
    public class MedicationDosesController : ApiController
    {
        public MedicationDosesController()
        {

        }

        [HttpGet]
        public IEnumerable<Report> History()
        {
            var meds = ConnectionTester.GetMedication();
            var prescriptions = ConnectionTester.GetPrescriptions();

            return from m in meds
                   join p in prescriptions on m.PrescriptionId equals p.PrescriptionID
                   orderby m.DateTimeConsumed descending
                   select new Report
                   {
                       MedicationID = m.MedicationID,
                       DateTimeConsumed = m.DateTimeConsumed,
                       Name = p.Name,
                       DoseTakenMG = m.DoseTakenMG,
                       DoseMG = p.DoseMG,
                       HalfLifeHrs = p.AverageHalfLifeHours
                   };
        }

        [Route("Olanzapine")]
        public IHttpActionResult Olanzapine([FromBody] [Required]MedDose dose)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            if (dose.Password == GetPassword(1))
                ConnectionTester.InsertOlanzapine(dose.consumedDateTime, dose.doseMg);
            return base.Ok();
        }        
       
        [Route("Sertraline")]        
        public IHttpActionResult Sertraline([FromBody] [Required]MedDose dose)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            if (dose.Password == GetPassword(1))
                ConnectionTester.InsertSertraline(dose.consumedDateTime, dose.doseMg);
            return base.Ok();
        }
        
        [Route("Delete/{medicationId:int}/{password}")]
        [HttpPost]
        [HttpDelete]
        public IHttpActionResult Delete([FromUri] [Required]int medicationId, [FromUri] [Required]string password)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            if(password == GetPassword(1))
                ConnectionTester.Delete(medicationId);
            return base.Ok();
        }       

        private string GetPassword(int personID)
        {
            return ConnectionTester.GetPassword(personID);
        }
    }
}