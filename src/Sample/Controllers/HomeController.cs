using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CoreLogging;
using CoreLogging.Extensions;
using Microsoft.AspNetCore.Mvc;
using sample.Models;

namespace sample.Controllers
{
    public class HomeController : Controller
    {
        readonly ICoreLogger<HomeController> _logger;

        public HomeController(ICoreLogger<HomeController> logger) => _logger = logger;

        public IActionResult Index()
        {
            _logger.LogInformation("Log message from injected ICoreLogger<T>.");
            ApplicationLogger.LogInformation(this, "Log message from ApplicationLogger.");
            this.LogInformation("Log message from an extension method.");
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
