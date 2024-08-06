using JobSearchManagementSystem.Application.Interfaces;
using JobSearchManagementSystem.Persistance.EntityFrameworks.DbContexts;
using JobSearchManagementSystem.Persistance.EntityFrameworks.Repositories;
using JobSearchManagementSystem.Persistance.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearchManagementSystem.Persistance
{
    public static class ServiceRegstration
    {
        public static void AddPersistanceServices(this IServiceCollection services,
                                                       IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Local");

            services
                .AddDbContext<JobSearchDbContext>(options => options
                .UseSqlServer(connectionString)
                .AddInterceptors(new UpdateBaseEntityInterceptor()));

            services.AddHttpContextAccessor();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }
    }
}
