using Autofac;
using Magpie.Framework.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Magpie.Web.Models.SqlModel
{
    public class CreateSqlModel : SqlBaseModel
    {
        public CreateSqlModel(IStockMarketService stockMarketService) : base(stockMarketService) {}
        public CreateSqlModel() : base() {}

        [Required]
        public DateTime date { get; set; }
        public int TradeCodeId { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float open { get; set; }
        public float close { get; set; }
        public decimal volumn { get; set; }

        public void Create()
        {
            
            var sm = new StockMarket
            {
                date = this.date,
                TradeCodeId= this.TradeCodeId,
                high = this.high,
                low=this.low,
                open=this.open,
                close=this.close,
                volumn=this.volumn
            };


            _stockMarketService.CreateStockMarket(sm);
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
