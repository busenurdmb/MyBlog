using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponent
{
    public class _DefaultHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
