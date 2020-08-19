using Magpie.Framework.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Magpie.Web.Models.SqlModel
{
    public class SqlModel : SqlBaseModel
    {
        public SqlModel(IStockMarketService stockMarketService) : base(stockMarketService) { }
        public SqlModel() : base() { }
        internal object GetStock(DataTablesAjaxRequestModel tableModel)
        {
            var data = _stockMarketService.GetStock(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "date", "trade_code", "high", "low", "open", "close", "volumn" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.date.ToString("dd/MM/yyyy"),
                                record.TradeCode.trade_code,
                                record.high.ToString(),
                                record.low.ToString(),
                                record.open.ToString(),
                                record.close.ToString(),
                                record.volumn.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }

        internal string Remove(int id)
        {
            var delete = _stockMarketService.DeleteStock(id);
            return delete.low.ToString();
        }
    }
}
