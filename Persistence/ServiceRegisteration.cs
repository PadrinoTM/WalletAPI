using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DbContext;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using System.Reflection;

namespace Persistence
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
                   IConfiguration config)
        {
            services.AddDbContext<UserWalletDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("WalletSolutionDb"),
                b => b.MigrationsAssembly(typeof(UserWalletDbContext).Assembly.FullName)), ServiceLifetime.Transient);

            services.AddScoped<IAccountRepository, AccountRepository>();

           


            return services;
        }

    }




}


