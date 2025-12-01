using Microsoft.EntityFrameworkCore;

namespace test
{
    public static class DataContextExtensionMethods
    {
        public static DbSet<TEntity> GetDBSetGeneric<TEntity>(this MedicationTaperDatabaseContext context) where TEntity : class
        {
            if (typeof(TEntity) == typeof(Alcohol))
                return context.Alcohols as DbSet<TEntity>;

            if (typeof(TEntity) == typeof(Sleep))
                return context.Sleeps as DbSet<TEntity>;

            if (typeof(TEntity) == typeof(ShoppingItem))
                return context.ShoppingItems as DbSet<TEntity>;
            

            return context.Set<TEntity>();
        }
    }
}
