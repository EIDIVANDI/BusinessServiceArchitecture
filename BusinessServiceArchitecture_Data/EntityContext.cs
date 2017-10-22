using BusinessServiceArchitecture_Data.DataEntities;
using System.Data.Entity;

namespace BusinessServiceArchitecture_Data
{
    public class EntityContext: DbContext
    {
        public EntityContext()
            : this(typeof(EntityContext).Assembly.GetName().Name) { }

        public EntityContext(string connectionstring)
            :base(connectionstring)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }

    }
}
