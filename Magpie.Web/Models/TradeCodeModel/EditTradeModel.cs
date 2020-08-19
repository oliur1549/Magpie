using Magpie.Framework.Trade;
using System;

namespace Magpie.Web.Models.TradeCodeModel
{
    public class EditTradeModel : TradeBaseModel
    {
        public EditTradeModel(ITradeCodeService tradeCodeService) : base(tradeCodeService) { }
        public EditTradeModel() : base() { }

        public int Id { get; set; }
        public string trade_code { get; set; }

        public void Edit()
        {

            var st = new TradeCode
            {
                Id=this.Id,
                trade_code = this.trade_code
            };


            _tradeCodeService.EditTradeCode(st);
        }
        internal void Load(int id)
        {
            var st = _tradeCodeService.GetTradeCode(id);

            if (st != null)
            {
                Id = st.Id;
                trade_code = st.trade_code;

            }
        }
    }
}
