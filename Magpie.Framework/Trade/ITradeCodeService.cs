using System;
using System.Collections.Generic;
using System.Text;

namespace Magpie.Framework.Trade
{
    public interface ITradeCodeService
    {
        (IList<TradeCode> records, int total, int totalDisplay) GetTradeCode(int pageIndex, int pageSize, string searchText, string sortText);

        void EditTradeCode(TradeCode st);
        TradeCode GetTradeCode(int id);
        TradeCode DeleteTradeCode(int id);
        void CreateTradeCode(TradeCode sm);
    }
}
