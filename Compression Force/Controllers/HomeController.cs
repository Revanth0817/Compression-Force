using Compression_Force.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Compression_Force.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        /*Diagnostics Page*/
        public IActionResult Diagnostics()
        {
            return View();
        }

        /*Report Pages*/
        public IActionResult Table()
        {
            return View();

        }
        public IActionResult Graph()
        {
            return View();

        }

        /*Auto Tare*/
        public IActionResult AutoTare()
        {
            return View();
        }

        public IActionResult Welcome()
        {
            return View();
        }

        /*Access Management*/
        public IActionResult AccessManagement()
        {
            return View();
        }



        /*Alarm page*/
        public IActionResult Alarm()
        {
            return View();
        }

        /*Audit Trail pages*/
        public IActionResult AuditTrail()
        {
            return View();
        }

        /*Auto Mode pages*/
        public IActionResult AutoMode()
        {
            return View();
        }

        /*Operation Mode pages*/
        public IActionResult OperationMode()
        {
            return View();
        }

        /*Batch pages*/
        public IActionResult Batch()
        {
            return View();
        }

        /*Calibration page*/
        public IActionResult Calibration()
        {
            return View();
        }

        public IActionResult ViewBatch()
        {
            return View();
        }

        /*Manual Mode*/
        public IActionResult ManualMode()
        {
            return View();
        }
        /*Signal Page*/
        public IActionResult Signal()
        {
            return View();
        }
    }
}

