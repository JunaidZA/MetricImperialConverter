using MetricImperialConverter.Common;
using System.Threading.Tasks;

namespace MetricImperialConverter.Service.Interfaces
{
    public interface IConvertService
    {
        /// <summary>
        /// Converts a unit between Metric and Imperial.
        /// </summary>
        /// <param name="amountToConvert"></param>
        /// <param name="conversionDirection"></param>
        /// <param name="conversionType"></param>
        /// <returns></returns>
        public Task<double> ConvertAsync(double amountToConvert, ConversionDirection conversionDirection, ConversionType conversionType);
    }
}
