
using Magpie.Framework.Json;
using Magpie.Framework.Trade;
using Microsoft.EntityFrameworkCore;

namespace Magpie.Framework
{
    public class DatabaseContext : DbContext
    {
        private string _connectionString;
        private string _migrationAssemblyName;

        public DatabaseContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(
                    _connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            builder.Entity<StockMarket>()
                .HasOne(p => p.TradeCode)
                .WithMany(i => i.StockMarkets)
                .HasForeignKey(p => p.TradeCodeId);

            base.OnModelCreating(builder);
        }

        public DbSet<StockMarket> StockMarkets { get; set; }
        public DbSet<TradeCode> TradeCodes { get; set; }

    }
}
