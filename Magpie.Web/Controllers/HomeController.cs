using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Magpie.Web.Models;
using Magpie.Framework;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Magpie.Web.Models.SqlModel;
using Autofac;
using Magpie.Framework.Json;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq;

namespace Magpie.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            var model = new SqlModel();
            return View(model);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult addstock()
        {
            var model = new CreateSqlModel();
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult addstock([Bind(nameof(CreateSqlModel.date),
            nameof(CreateSqlModel.TradeCodeId),
            nameof(CreateSqlModel.high),
            nameof(CreateSqlModel.low),
            nameof(CreateSqlModel.open),
            nameof(CreateSqlModel.close),
            nameof(CreateSqlModel.volumn)
            )]
        CreateSqlModel model)
        {
            if (ModelState.IsValid)
            {
                    model.Create();
                    return RedirectToAction("index");

            }
            return View(model);

        }

        public IActionResult editstock(int id)
        {
            var model = new EditSqlModel();
            model.Load(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult editstock([Bind(nameof(EditSqlModel.Id),
            nameof(EditSqlModel.date),
            nameof(EditSqlModel.TradeCodeId),
            nameof(EditSqlModel.high),
            nameof(EditSqlModel.low),
            nameof(EditSqlModel.open),
            nameof(EditSqlModel.close),
            nameof(EditSqlModel.volumn)
            )]
        EditSqlModel model)
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
        public IActionResult deletestock(int id)
        {
            var model = new SqlModel();
            model.Remove(id);
            return View("index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult GetStock()
        {
            var tableModel = new DataTablesAjaxRequestModel(Request);
            var model = Startup.AutofacContainer.Resolve<SqlModel>();
            var data = model.GetStock(tableModel);
            return Json(data);
        }
        
    }
}
