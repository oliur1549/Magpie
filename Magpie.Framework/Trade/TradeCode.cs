using Magpie.Data;
using Magpie.Framework.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magpie.Framework.Trade
{
    public class TradeCode : IEntity<int>
    {
        public int Id { get; set; }
        public string trade_code { get; set; }

        public IList<StockMarket> StockMarkets { get; set; }
    }
}
