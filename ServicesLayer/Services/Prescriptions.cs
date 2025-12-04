using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test;

namespace ServicesLayer.Services
{
    public class Prescriptions : IPrescriptionDataAccess
    {
        public Prescriptions(MedicationTaperDatabaseContext databaseContext, IMapper mapper, ILogger<Prescriptions> logger)
        { 
            this._databaseContext = databaseContext;
            _mapper = mapper;
            _logger = logger;
        }

        MedicationTaperDatabaseContext _databaseContext;
        IMapper _mapper;
        ILogger _logger;
        public IEnumerable<DataAccessLayer.Models.Prescription> GetPrescriptions(long personID)
        {           
            _logger.LogInformation($"Getting prescriptions for person ID {personID}");            
            
            var prescriptions = from p in _databaseContext.Prescriptions
                                where p.PersonId == personID
                                select p;

            var ps = prescriptions.ToList();
            return _mapper.Map<List<DataAccessLayer.Models.Prescription>>(ps);                   
        }
    }
}
