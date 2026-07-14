using IMS.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace IMS.Infrastructure.Data
{
    public class IMSDbContext : DbContext
    {
        public IMSDbContext(DbContextOptions<IMSDbContext> options)
            : base(options)
        {
        }

        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Area> Areas => Set<Area>();
        public DbSet<Priority> Priorities => Set<Priority>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IMSDbContext).Assembly);
        }
    }
}
