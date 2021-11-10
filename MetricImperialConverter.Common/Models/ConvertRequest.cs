using System.ComponentModel.DataAnnotations;

namespace MetricImperialConverter.Common.Models
{
    public class ConvertRequest
    {
        /// <summary>
        /// The amount to convert.
        /// </summary>
        [Required]
        public double AmountToConvert { get; set; }
        /// <summary>
        /// The direction in which to convert (Imperial to Metric or Metric to Imperial).
        /// </summary>
        [Required]
        public ConversionDirection ConversionDirection { get; set; }
        /// <summary>
        /// The type of conversion (Length, Temperature or Mass).
        /// </summary>
        [Required]
        public ConversionType ConversionType { get; set; }
    }
}
