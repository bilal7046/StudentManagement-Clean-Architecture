using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using StudentManagement.Application.ModelValidator;
using System.Reflection;

namespace StudentManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Validators

            //services.AddValidatorsFromAssembly(typeof(StudentValidator).Assembly);
            services.AddValidatorsFromAssemblyContaining<StudentValidator>();

            #endregion Validators

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}