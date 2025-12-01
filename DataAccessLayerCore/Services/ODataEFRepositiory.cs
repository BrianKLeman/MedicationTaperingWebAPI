using Data.Services.Interfaces.IModels;
using Data.Services.Interfaces.IRespository;
using test;

namespace DataAccessLayerCore.Services
{    
    public class EFDataAccessBase
    {
        public EFDataAccessBase(MedicationTaperDatabaseContext dbContext) 
        { 
            this.DatabaseContext = dbContext;
        }

        public MedicationTaperDatabaseContext DatabaseContext { get; set; }
    }

    public class ODataEFRepository<T> :EFDataAccessBase, IODataRepository<T>, IDisposable where T : class, IPersonID, IId
    {
        public ODataEFRepository(MedicationTaperDatabaseContext connectionStringProvider)
            : base(connectionStringProvider)
        {
            
        }

        public void Dispose()
        {

        }

        public IQueryable<T> Get(long personCode)
        {
            return DatabaseContext.GetDBSetGeneric<T>().Where( x => x.PersonId == personCode);
        }

        public Task<int> Update(long personCode, T record)
        {
            var exists = this.DatabaseContext.GetDBSetGeneric<T>().Where(x => x.PersonId == personCode && x.Id == record.Id)?.FirstOrDefault();
            if (exists != null)
            {
                this.DatabaseContext.GetDBSetGeneric<T>().Update(exists);
                return this.DatabaseContext.SaveChangesAsync();
            }

            return new Task<int>(() => -1); // Fake task.
        }
    }    
}
