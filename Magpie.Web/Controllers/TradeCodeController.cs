using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Magpie.Web.Models;
using Magpie.Web.Models.TradeCodeModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Magpie.Web.Controllers
{
    public class TradeCodeController : Controller
    {
        private readonly IConfiguration _configuration;

        public TradeCodeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {

            var model = new TradeModel();
            return View(model);
        }
        public IActionResult addtrade()
        {
            var model = new CreateTradeModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addtrade([Bind(
            nameof(CreateTradeModel.trade_code))]
        CreateTradeModel model)
        {
            if (ModelState.IsValid)
            {
                model.Create();
                return RedirectToAction("index");

            }
            return View(model);

        }
        public IActionResult edittrade(int id)
        {
            var model = new EditTradeModel();
            model.Load(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult edittrade([Bind(nameof(EditTradeModel.Id),
            nameof(EditTradeModel.trade_code))]
        EditTradeModel model)
        {
            if (ModelState.IsValid)
            {
                model.Edit();
                return RedirectToAction("index");

            }
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult deletetrade(int id)
        {
            var model = new TradeModel();
            model.Remove(id);
            return View("index");
        }
        public IActionResult GetTradeCode()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<TradeModel>();
            var data = model.GetTradeCode(tableModel);
            return Json(data);
        }
    }
}
