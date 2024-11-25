using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Domain.Common;
using StudentManagement.Domain.Entities;
using StudentManagement.Infrastructure.Configurations;
using StudentManagement.Infrastructure.IRepository;

namespace StudentManagement.Infrastructure.Data
{
    public class StudentContext : DbContext
    {
        private readonly IAuditTrailRepository _auditTrailRepository;
        private readonly IServiceProvider _serviceProvider;
        public DbSet<Student> Student { get; set; }
        public DbSet<AuditTrail> AuditTrail { get; set; }

        public StudentContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options)
        {
            _serviceProvider = serviceProvider;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new StudentConfiguration());
            //builder.ApplyConfigurationsFromAssembly(typeof(CarTechContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseAuditableEntity>())
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreateAt = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}