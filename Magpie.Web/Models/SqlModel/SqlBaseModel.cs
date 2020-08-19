using Autofac;
using Magpie.Framework.Json;
using Magpie.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magpie.Web.Models.SqlModel
{
    public class SqlBaseModel
    {
        protected readonly IStockMarketService _stockMarketService;

        public SqlBaseModel(IStockMarketService stockMarketService)
        {
            _stockMarketService = stockMarketService;
        }

        public SqlBaseModel()
        {
            _stockMarketService = Startup.AutofacContainer.Resolve<IStockMarketService>();
        }
    }
}
