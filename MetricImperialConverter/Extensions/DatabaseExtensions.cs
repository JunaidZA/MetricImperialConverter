using MetricImperialConverter.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace MetricImperialConverter.Api.Extensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var dbPath = $"{configuration.GetConnectionString("ConversionDB")}";
            var connectionString = $"Data Source={dbPath}";

            serviceCollection.AddEntityFrameworkSqlite().AddDbContext<ConversionDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            return serviceCollection;
        }
    }
}
