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
        public DbSet<Status> Statuses => Set<Status>();
        public DbSet<User> Users => Set<User>();
        public DbSet<UserCredentials> UserCredentials => Set<UserCredentials>();
        public DbSet<UserRole> UserRoles => Set<UserRole>();
        public DbSet<Incident> Incidents => Set<Incident>();
        public DbSet<IncidentComment> IncidentComments => Set<IncidentComment>();
        public DbSet<IncidentAttachment> IncidentAttachments => Set<IncidentAttachment>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(IMSDbContext).Assembly);
        }
    }
}
