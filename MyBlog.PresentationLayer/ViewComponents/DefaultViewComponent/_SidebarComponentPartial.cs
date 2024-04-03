using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponent
{
    public class _SidebarComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
