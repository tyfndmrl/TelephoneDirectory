using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TelephoneDirectory.Framework.Repository.Models.Configurations;
using TelephoneDirectory.Framework.Repository.Repositories;
using TelephoneDirectory.Framework.Repository.Repositories.Interfaces;

namespace TelephoneDirectory.Framework.Repository.Extensions
{
    public static class RepositoryManager
    {
        public static void MongoRepositoryInit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));
            services.Configure<MongoConfiguration>(configuration.GetSection("MongoDBConfiguration"));
        }
    }
}
