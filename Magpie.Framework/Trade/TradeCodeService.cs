using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Magpie.Framework.Trade
{
    public class TradeCodeService : ITradeCodeService
    {
        public IStockUnitOfWork _stockMarketUnitOfWork;
        public TradeCodeService(IStockUnitOfWork stockMarketUnitOfWork)
        {
            _stockMarketUnitOfWork = stockMarketUnitOfWork;
        }

        public void CreateTradeCode(TradeCode sm)
        {
            _stockMarketUnitOfWork.TradeCodeRepository.Add(sm);
            _stockMarketUnitOfWork.Save();
            
        }

        public TradeCode DeleteTradeCode(int id)
        {
            var Prop = _stockMarketUnitOfWork.TradeCodeRepository.GetById(id);
            _stockMarketUnitOfWork.TradeCodeRepository.Remove(Prop);
            _stockMarketUnitOfWork.Save();
            return Prop;
        }

        public void EditTradeCode(TradeCode st)
        {
            var Prop = _stockMarketUnitOfWork.TradeCodeRepository.GetById(st.Id);
            Prop.Id = st.Id;
            Prop.trade_code = st.trade_code;
            _stockMarketUnitOfWork.Save();
        }

        public (IList<TradeCode> records, int total, int totalDisplay) GetTradeCode(int pageIndex, int pageSize, string searchText, string sortText)
        {
            if (searchText != null)
            {
                return _stockMarketUnitOfWork.TradeCodeRepository.GetTradeCode(
                    e => e.trade_code.Contains(searchText) , 
                    sortText, null, pageIndex, pageSize, false);
            }
            else
            {
                return _stockMarketUnitOfWork.TradeCodeRepository.GetTradeCode(
                    null, sortText, null, pageIndex, pageSize, false);
            }
        }

        public TradeCode GetTradeCode(int id)
        {
            return _stockMarketUnitOfWork.TradeCodeRepository.GetById(id);
        }
    }
}
