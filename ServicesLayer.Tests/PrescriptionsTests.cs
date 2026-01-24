using DataAccessLayer;
using ServicesLayer.Services;
namespace ServicesLayer.Tests
{
    public class PrescriptionsTests
    {
        private IPrescriptionDataAccess Prescriptions;
        [SetUp]
        public void Setup()
        {
            //Prescriptions = new ServicesLayer.Services.Prescriptions();
            // I need to start Using an InMemory representation of the database for testing
            // the service layer.

        }

        [Test]
        public void InvalidPersonCodeReturnsEmptyArray()
        {
            Assert.Pass("Testing github passing test execution.");
        }
    }
}
