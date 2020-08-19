using Magpie.Data;
using Magpie.Framework.Trade;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Magpie.Framework.Trade
{
    public interface ITradeCodeRepository : IRepository<TradeCode, int, DatabaseContext>
    {
        (IList<TradeCode> records, int total, int totalDisplay) GetTradeCode(
            Expression<Func<TradeCode, bool>> filter = null,
            string orderBy = null,
            Func<IQueryable<TradeCode>, IIncludableQueryable<TradeCode, object>> include = null,
            int pageIndex = 1, int pageSize = 10, bool isTrackingOff = false);
    }
}
