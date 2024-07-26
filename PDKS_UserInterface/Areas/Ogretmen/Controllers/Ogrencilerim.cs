using Microsoft.AspNetCore.Mvc;

namespace PDKS_UserInterface.Areas.Ogretmen.Controllers
{
    public class Ogrencilerim : Controller
    {
        [Area("Ogretmen")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
