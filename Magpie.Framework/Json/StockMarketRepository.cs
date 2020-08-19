using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Magpie.Data;

namespace Magpie.Framework.Json
{
    public class StockMarketRepository : Repository<StockMarket, int, DatabaseContext>, IStockMarketRepository
    {
        public StockMarketRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }
        public (IList<StockMarket> records, int total, int totalDisplay) GetStock(
           Expression<Func<StockMarket, bool>> filter = null, string orderBy = null,
           Func<IQueryable<StockMarket>, IIncludableQueryable<StockMarket, object>> include = null,
           int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false)
        {
            IQueryable<StockMarket> query = _dbSet;
            var total = query.Count();
            var totalDisplay = query.Count();

            if (filter != null)
            {
                query = query.Where(filter);
                totalDisplay = query.Count();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (orderBy != null)
            {
                var result = query.OrderBy(orderBy).Skip((pageIndex - 1) * pageSize).Take(pageSize);
                if (isTrackingOff)
                    return (result.AsNoTracking().ToList(), total, totalDisplay);
                else
                    return (result.ToList(), total, totalDisplay);
            }
            else
            {
                var result = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
                if (isTrackingOff)
                    return (result.AsNoTracking().ToList(), total, totalDisplay);
                else
                    return (result.ToList(), total, totalDisplay);
            }
        }
    }
}
