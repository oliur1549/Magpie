using Magpie.Framework.Trade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Magpie.Framework.Json
{
    public class StockMarketService : IStockMarketService
    {
        public IStockUnitOfWork _stockMarketUnitOfWork;
        public StockMarketService(IStockUnitOfWork stockMarketUnitOfWork)
        {
            _stockMarketUnitOfWork = stockMarketUnitOfWork;
        }

        public void CreateStockMarket(StockMarket sm)
        {
            _stockMarketUnitOfWork.StockMarketRepository.Add(sm);
            _stockMarketUnitOfWork.Save();
            
        }

        public StockMarket DeleteStock(int id)
        {
            var Prop = _stockMarketUnitOfWork.StockMarketRepository.GetById(id);
            _stockMarketUnitOfWork.StockMarketRepository.Remove(Prop);
            _stockMarketUnitOfWork.Save();
            return Prop;
        }

        public void EditStock(StockMarket st)
        {
            var Prop = _stockMarketUnitOfWork.StockMarketRepository.GetById(st.Id);
            Prop.Id = st.Id;
            Prop.date = st.date;
            Prop.TradeCodeId = st.TradeCodeId;
            Prop.high = st.high;
            Prop.low = st.low;
            Prop.open = st.open;
            Prop.close = st.close;
            Prop.volumn = st.volumn;
            _stockMarketUnitOfWork.Save();
        }

        public (IList<StockMarket> records, int total, int totalDisplay) GetStock(int pageIndex, int pageSize, string searchText, string sortText)
        {
            if (searchText != null)
            {
                return _stockMarketUnitOfWork.StockMarketRepository.GetStock(
                    e =>  e.TradeCode.trade_code.Contains(searchText),
                    sortText, e => e.Include(c => c.TradeCode), pageIndex, pageSize, false);
            }
            else
            {
                return _stockMarketUnitOfWork.StockMarketRepository.GetStock(
                    null, sortText, e => e.Include(c => c.TradeCode), pageIndex, pageSize, false);
            }
        }

        public StockMarket GetStock(int id)
        {
            return _stockMarketUnitOfWork.StockMarketRepository.GetById(id);
        }

        public IEnumerable<TradeCode> GetTradeCode()
        {
            return _stockMarketUnitOfWork.TradeCodeRepository.GetAll().ToList();
        }
    }
}
