using Manager4.data.entity;
using System.Data.Entity;

namespace Manager4.common
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(App.setting.ConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DatabaseContext, Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>();
            modelBuilder.Entity<EyeEntity>();
            modelBuilder.Entity<ReportEntity>();
            modelBuilder.Entity<PrescriptionEntity>();
            modelBuilder.Entity<CustomerEntity>();
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<EyeEntity> Eyes { get; set; }
        public DbSet<ReportEntity> Reports { get; set; }
        public DbSet<PrescriptionEntity> Prescriptions { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
    }
}
