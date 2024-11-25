using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Infrastructure.Data;
using StudentManagement.Infrastructure.IRepository;
using StudentManagement.Infrastructure.Repository;

namespace StudentManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            services.AddDbContext<StudentContext>(
                                              option => option.UseSqlServer(connectionString,
                                              b =>
                                              {
                                                  b.MigrationsAssembly(typeof(StudentContext).Assembly.FullName);
                                                  b.CommandTimeout(180);
                                              })
                                             .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking), ServiceLifetime.Transient);

            services.AddScoped<IUnitOfWorkRepository, UnitOfWorkRepository>();
            services.AddScoped<IAuditTrailRepository, AuditTrailRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddTransient<IAuditTrailRepository, AuditTrailRepository>();

            return services;
        }
    }
}