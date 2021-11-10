using MetricImperialConverter.Common;
using MetricImperialConverter.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MetricImperialConverter.Data
{
    public class ConversionDbContext : DbContext
    {
        public DbSet<ConversionRates> ConversionRates { get; set; }

        public ConversionDbContext(DbContextOptions<ConversionDbContext> options)
            : base(options)
        {
            base.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConversionRates>().ToTable("ConversionRates", "dbo");

            modelBuilder.Entity<ConversionRates>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PrimaryKey_ConversionRatesId");
                entity.HasIndex(e => e.Id).IsUnique();
            });

            modelBuilder.Entity<ConversionRates>().HasData(
                new ConversionRates // Fahrenheit to Celsius
                {
                    Id = 1,
                    Type = (int)ConversionType.Temperature,
                    Direction = (int)ConversionDirection.ImperialToMetric,
                    Formula = "({value} - 32) * 5/9"
                },
                new ConversionRates // Celsius to Fahrenheit
                {
                    Id = 2,
                    Type = (int)ConversionType.Temperature,
                    Direction = (int)ConversionDirection.MetricToImperial,
                    Formula = "({value} * 9/5) + 32"
                },
                new ConversionRates // Feet to Meters
                {
                    Id = 3,
                    Type = (int)ConversionType.Length,
                    Direction = (int)ConversionDirection.ImperialToMetric,
                    Formula = "({value}/3.281)"
                },
                new ConversionRates // Meters to Feet
                {
                    Id = 4,
                    Type = (int)ConversionType.Length,
                    Direction = (int)ConversionDirection.MetricToImperial,
                    Formula = "({value}/0.3048)"
                },
                new ConversionRates // Ounces to Grams
                {
                    Id = 5,
                    Type = (int)ConversionType.Mass,
                    Direction = (int)ConversionDirection.ImperialToMetric,
                    Formula = "({value}*28.34952)"
                },
                new ConversionRates // Grams to Ounces
                {
                    Id = 6,
                    Type = (int)ConversionType.Mass,
                    Direction = (int)ConversionDirection.MetricToImperial,
                    Formula = "({value}/28.34952)"
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
