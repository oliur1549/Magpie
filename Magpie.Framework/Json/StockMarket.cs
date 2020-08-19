using Magpie.Data;
using Magpie.Framework.Trade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magpie.Framework.Json
{
    public class StockMarket : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public int TradeCodeId { get; set; }
        public virtual TradeCode TradeCode { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float open { get; set; }
        public float close { get; set; }
        public decimal volumn { get; set; }
    }
}
