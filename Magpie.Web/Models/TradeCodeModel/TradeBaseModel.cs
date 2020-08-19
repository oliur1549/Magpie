using Autofac;
using Magpie.Framework.Trade;

namespace Magpie.Web.Models.TradeCodeModel
{
    public class TradeBaseModel
    {
        protected readonly ITradeCodeService _tradeCodeService;

        public TradeBaseModel(ITradeCodeService tradeCodeService)
        {
            _tradeCodeService = tradeCodeService;
        }

        public TradeBaseModel()
        {
            _tradeCodeService = Startup.AutofacContainer.Resolve<ITradeCodeService>();
        }
    }
}
