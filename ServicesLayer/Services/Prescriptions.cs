using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Repository;
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
        public Prescriptions(MedicationTaperDatabaseContext databaseContext, IMapper mapper)
        { 
            this._databaseContext = databaseContext;
            _mapper = mapper;
        }

        MedicationTaperDatabaseContext _databaseContext;
        IMapper _mapper;
        public IEnumerable<DataAccessLayer.Models.Prescription> GetPrescriptions(long personID)
        {           
            if (personID > PersonDataAccess.INVALID_PERSON_CODE)
            {
                var prescriptions = from p in _databaseContext.Prescriptions
                                    where p.PersonId == personID
                                    select p;

                var ps = prescriptions.ToList();
                return _mapper.Map<List<DataAccessLayer.Models.Prescription>>(ps);
            }
            else
            {
                return new DataAccessLayer.Models.Prescription[0];
            }            
        }
    }
}
