using Magpie.Data;
using Magpie.Framework;
using Magpie.Framework.Json;
using Magpie.Framework.Trade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magpie.Framework
{
    public class StockUnitOfWork : UnitOfWork, IStockUnitOfWork
    {
        public IStockMarketRepository StockMarketRepository { get ; set ; }
        public ITradeCodeRepository TradeCodeRepository { get ; set ; }

        public StockUnitOfWork(DatabaseContext databaseContext,
            IStockMarketRepository stockMarketRepository,
            ITradeCodeRepository tradeCodeRepository)
            : base(databaseContext)
        {
            StockMarketRepository = stockMarketRepository;
            TradeCodeRepository = tradeCodeRepository;
        }
    }
}
