using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponent
{
    public class _NavbarComponetPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
