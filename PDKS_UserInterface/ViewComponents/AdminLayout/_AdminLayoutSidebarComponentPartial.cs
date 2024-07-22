using Microsoft.AspNetCore.Mvc;

namespace PDKS_UserInterface.ViewComponents.AdminLayout
{
    public class _AdminLayoutSidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {

        return View(); 
        }
    }
}
