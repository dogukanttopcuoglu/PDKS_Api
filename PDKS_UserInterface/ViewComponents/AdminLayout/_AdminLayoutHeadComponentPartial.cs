using Microsoft.AspNetCore.Mvc;

namespace PDKS_UserInterface.ViewComponents._AdminLayoutHeadComponentPartial
{
    public class _AdminLayoutHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
        return View(); 
        }
    }
}
