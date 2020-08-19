using Magpie.Framework.Trade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magpie.Framework.Json
{
    public interface IStockMarketService
    {
        (IList<StockMarket> records, int total, int totalDisplay) GetStock(int pageIndex, int pageSize, string searchText, string sortText);

        void EditStock(StockMarket st);
        StockMarket GetStock(int id);
        StockMarket DeleteStock(int id);
        void CreateStockMarket(StockMarket sm);
        IEnumerable<TradeCode> GetTradeCode();
    }
}
