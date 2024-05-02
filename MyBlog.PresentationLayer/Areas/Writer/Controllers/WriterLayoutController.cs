using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [AllowAnonymous]
    public class WriterLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
