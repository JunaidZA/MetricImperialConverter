using System.ComponentModel.DataAnnotations;

namespace MetricImperialConverter.Data.Models
{
    public class ConversionRates
    {
        [Key]
        public int Id { get; set; }
        public int Type { get; set; }
        public int Direction { get; set; }
        public string Formula { get; set; }
    }
}
