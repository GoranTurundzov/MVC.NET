using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.PizzaApp.DataAccess;
using SEDC.PizzaApp.DataAccess.Repositories;
using SEDC.PizzaApp.DataAccess.Repositories.EntityRepository;
using SEDC.PizzaApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.PizzaApp.Services.Helpers
{
    public static class DiModule
    {
        public static IServiceCollection RegisterRepositories(IServiceCollection services , string connectionString)
        {
            services.AddTransient<IRepository<User>, UserEntityRepository>();
            services.AddTransient<IRepository<Pizza>, PizzaEntityRepository>();
            services.AddTransient<IRepository<Order>, OrderEntityRepository>();

            services.AddDbContext<PizzaDbContext>(x => x.UseSqlServer(connectionString));
            return services;
        }
    }
}
