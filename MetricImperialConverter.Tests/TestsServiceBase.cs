using MetricImperialConverter.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MetricImperialConverter.Tests
{
    public abstract class TestsServiceBase
    {
        protected DbContextOptions<ConversionDbContext> _dbContextOptions;
        protected SqliteConnection _connection;
        protected ConversionDbContext _dbContext;

        public async Task SetUp()
        {
            await SetUpDatabase();
        }

        public async Task SetUpDatabase()
        {
            var connectionString = $"DataSource=myshareddb;mode=memory;cache=shared";
            _connection = new SqliteConnection(connectionString);
            _connection.Open();

            _dbContextOptions = new DbContextOptionsBuilder<ConversionDbContext>().UseSqlite(connectionString).Options;

            _dbContext = new ConversionDbContext(_dbContextOptions);
            await _dbContext.Database.EnsureCreatedAsync();
        }

    }
}
