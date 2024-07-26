using Microsoft.AspNetCore.Mvc;

namespace PDKS_UserInterface.Areas.Ogretmen.Controllers
{
    public class LayoutOgretmenController : Controller
    {
        [Area("Ogretmen")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
