using Magpie.Framework.Trade;
using System.Linq;

namespace Magpie.Web.Models.TradeCodeModel
{
    public class TradeModel : TradeBaseModel
    {
        public TradeModel(ITradeCodeService tradeCodeService) : base(tradeCodeService) { }
        public TradeModel() : base() { }
        internal object GetTradeCode(DataTablesAjaxRequestModel tableModel)
        {
            var data = _tradeCodeService.GetTradeCode(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] {  "trade_code" }));

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.trade_code,
                                record.Id.ToString()
                        }
                    ).ToArray()

            };
        }

        internal string Remove(int id)
        {
            var delete = _tradeCodeService.DeleteTradeCode(id);
            return delete.trade_code;
        }
    }
}
