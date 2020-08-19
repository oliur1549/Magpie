using Magpie.Framework.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Magpie.Web.Models.SqlModel
{
    public class EditSqlModel : SqlBaseModel
    {
        public EditSqlModel(IStockMarketService stockMarketService) : base(stockMarketService) { }
        public EditSqlModel() : base() { }

        public int Id { get; set; }
        public DateTime date { get; set; }
        public int TradeCodeId { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float open { get; set; }
        public float close { get; set; }
        public decimal volumn { get; set; }

        public void Edit()
        {

            var st = new StockMarket
            {
                Id=this.Id,
                date = this.date,
                TradeCodeId = this.TradeCodeId,
                high = this.high,
                low = this.low,
                open = this.open,
                close = this.close,
                volumn = this.volumn
            };


            _stockMarketService.EditStock(st);
        }
        internal void Load(int id)
        {
            var st = _stockMarketService.GetStock(id);

            if (st != null)
            {
                Id = st.Id;
                date = st.date;
                TradeCodeId = st.TradeCodeId;
                high = st.high;
                low = st.low;
                open = st.open;
                close = st.close;
                volumn = st.volumn;

            }
        }
        public IList<SelectListItem> GetStockList()
        {
            IList<SelectListItem> listItems = new List<SelectListItem>();

            foreach (var item in _stockMarketService.GetTradeCode())
            {
                var ctg = new SelectListItem
                {
                    Text = item.trade_code,
                    Value = item.Id.ToString()
                };
                listItems.Add(ctg);
            }
            return listItems;
        }
    }
}
