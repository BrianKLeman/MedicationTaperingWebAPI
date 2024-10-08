using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Http;
using WebAppApi48.Services;
using Resolver = System.Web.Mvc.DependencyResolver;
namespace WebAppApi48.Controllers
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

    [RoutePrefix("Api/MedicationDoses")]
    public class MedicationDosesController : ApiController
    {

        public MedicationDosesController()
        {
            this.authService = Resolver.Current.GetService(typeof(IAuthService)) as IAuthService;
            this.dataAccess = Resolver.Current.GetService(typeof(IMedicationDataAccess)) as IMedicationDataAccess;
            this.prescriptions = Resolver.Current.GetService(typeof(IPrescriptionDataAccess)) as IPrescriptionDataAccess;
        }

        private IAuthService authService;
        private IMedicationDataAccess dataAccess;
        private IPrescriptionDataAccess prescriptions;
        
        public IEnumerable<Report> Get()
        {
            var personID = this.authService.VerifyCredentials(Request);            

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
        
        
        [Route("{medicationId:int}")]
        public IHttpActionResult Delete([FromUri] [Required]int medicationId)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            // Get person ID for user and password.
            var personID = this.authService.VerifyCredentials(Request);

            dataAccess.Delete(personID,medicationId);
            return base.Ok();
        }
        

        public IHttpActionResult Post([FromBody][Required] MedDose dose)
        {
            if (ModelState.IsValid == false)
                return BadRequest(ModelState);

            var personID = this.authService.VerifyCredentials(Request);

            dataAccess.InsertMedication(personID, dose.consumedDateTime, dose.PrescriptionID, dose.doseMg);
            return base.Ok();
        }
    }
}