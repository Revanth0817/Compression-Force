using Microsoft.AspNetCore.Mvc;

namespace Compression_Force.Controllers
{
    public class AccountManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
