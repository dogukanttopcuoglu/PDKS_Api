using Microsoft.AspNetCore.Mvc;

namespace PDKS_UserInterface.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
