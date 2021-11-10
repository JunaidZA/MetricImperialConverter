using MetricImperialConverter.Service;
using MetricImperialConverter.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MetricImperialConverter.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IConvertService, ConvertService>();
            return serviceCollection;
        }
    }
}
