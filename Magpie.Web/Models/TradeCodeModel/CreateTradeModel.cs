using Magpie.Framework.Trade;
using System;

namespace Magpie.Web.Models.TradeCodeModel
{
    public class CreateTradeModel : TradeBaseModel
    {
        public CreateTradeModel(ITradeCodeService tradeCodeService) : base(tradeCodeService) { }
        public CreateTradeModel() : base() { }

        
        public string trade_code { get; set; }

        public void Create()
        {
            
            var sm = new TradeCode
            {
                trade_code= this.trade_code
            };


            _tradeCodeService.CreateTradeCode(sm);
        }
    }
}
