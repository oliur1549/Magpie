using Magpie.Data;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Magpie.Framework.Json
{
    public interface IStockMarketRepository : IRepository<StockMarket, int, DatabaseContext>
    {
        (IList<StockMarket> records, int total, int totalDisplay) GetStock(
            Expression<Func<StockMarket, bool>> filter = null,
            string orderBy = null,
            Func<IQueryable<StockMarket>, IIncludableQueryable<StockMarket, object>> include = null,
            int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
    }
}
