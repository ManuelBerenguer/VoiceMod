using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceMod.Users.Core.Repositories;
using VoiceMod.Users.Infrastructure.Data.EF.Repositories;
using VoiceMod.Users.Infrastructure.Data.EF.Extensions;

namespace VoiceMod.Users.Api.Configuration.EF
{
    public static class EFSetup
    {
        private const string ConnectionStringPropertyName = "ConnectionString";
        private const string UseInMemoryDataBasePropertyName = "UseInMemoryDatabase";
        private const string InMemoryDataBaseName = "Users";

        public static IServiceCollection AddEFConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var useInMemoryDatabase = configuration.GetSection("Settings").GetValue<bool>(UseInMemoryDataBasePropertyName);

            services.AddEFDbConfiguration(configuration, useInMemoryDatabase, InMemoryDataBaseName, 
                configuration.GetSection("Settings").GetValue<string>(ConnectionStringPropertyName));

            // Repository implementations
            services.AddScoped<IUsersRepository, EfUsersRepository>();

            return services;
        }
    }
}
