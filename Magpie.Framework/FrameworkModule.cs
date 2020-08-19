using Autofac;
using Magpie.Framework.Json;
using Magpie.Framework.Trade;

namespace Magpie.Framework
{
    public class FrameworkModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public FrameworkModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DatabaseContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<StockUnitOfWork>().As<IStockUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StockMarketRepository>().As<IStockMarketRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StockMarketService>().As<IStockMarketService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TradeCodeRepository>().As<ITradeCodeRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<TradeCodeService>().As<ITradeCodeService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
