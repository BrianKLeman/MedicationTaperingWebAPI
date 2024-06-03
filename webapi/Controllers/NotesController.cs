using DataAccessLayer;

namespace webapi.Controllers
{
    public class MedicationDose
    {
        public long MedicationID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string CreatedUser { get; set; }
        public string UpdatedUser { get; set; }
        public long PrescriptionID { get; set; }
        public decimal DoseTakenMg { get; set; }
        public DateTime? DateTimeConsumed { get; set; }
        public long PersonID { get; set; }
        public string ConnectionResult { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class MedicationDosesController : ControllerBase
    {

        private readonly ILogger<MedicationDosesController> _logger;

        public MedicationDosesController(ILogger<MedicationDosesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<MedicationDose> Get()
        {
            string connectionResult = ConnectionTester.Do();
            return Enumerable.Range(1, 5).Select(index => new MedicationDose
            {
                ConnectionResult = connectionResult,
                CreatedDate = DateTime.Now.AddDays(index),
                DateTimeConsumed = DateTime.Now.AddDays(index),
                PrescriptionID = 3,
                PersonID = 1,
                DoseTakenMg = index
            })
            .ToArray();
        }
    }
}