using Magpie.Data;
using Magpie.Framework.Json;
using Magpie.Framework.Trade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magpie.Framework
{
    public interface IStockUnitOfWork : IUnitOfWork
    {
        IStockMarketRepository StockMarketRepository { get; set; }
        ITradeCodeRepository TradeCodeRepository { get; set; }

    }
}
