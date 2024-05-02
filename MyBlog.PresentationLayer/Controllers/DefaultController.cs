using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly ITagService _tagService;

        public DefaultController(ITagService tagService)
        {
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            var value=_tagService.TGetListAll().ToList();
            return View(value);
        }
    }
}
