using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using VoiceMod.Users.Infrastructure.Data.EF.Data;

namespace VoiceMod.Users.Infrastructure.Data.EF.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddEFDbConfiguration(this IServiceCollection services, IConfiguration configuration,  bool inMemoryDb, string inMemoryDbName,
            string connectionString)
        {
            services.AddDbContext<UsersDbContext>(options =>
            {
                if (inMemoryDb)
                {
                    options.UseInMemoryDatabase(inMemoryDbName);
                }
                else
                {
                    options.UseSqlServer(connectionString);
                }
            });

            return services;
        }
    }
}
