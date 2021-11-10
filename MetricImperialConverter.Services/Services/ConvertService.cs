using MetricImperialConverter.Common;
using MetricImperialConverter.Data;
using MetricImperialConverter.Service.Interfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace MetricImperialConverter.Service
{
    public class ConvertService : IConvertService
    {
        private readonly ConversionDbContext _context;

        public ConvertService(ConversionDbContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<double> ConvertAsync(double amountToConvert, ConversionDirection conversionDirection, ConversionType conversionType)
        {
            var conversionRate = await _context.ConversionRates.SingleOrDefaultAsync(conversionRate => conversionRate.Type == (int)conversionType && conversionRate.Direction == (int)conversionDirection);
            if (conversionRate == null)
            {
                throw new ArgumentException("Conversion not found");
            }

            var expression = conversionRate.Formula.Replace("{value}", amountToConvert.ToString());

            var dt = new DataTable();
            var computeResult = dt.Compute(expression, string.Empty);
            if (!double.TryParse(computeResult?.ToString(), out double convertedAmount))
            {
                throw new Exception("Invalid expression output");
            }

            return Math.Round(convertedAmount,3);
        }
    }
}
