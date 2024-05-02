using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("/Admin/Blog")]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;

        public BlogController(UserManager<AppUser> userManager, IArticleService articleService)
        {
            _userManager = userManager;
            _articleService = articleService;
        }
        [Route("Index")]

        public IActionResult Index()
        {
            var values = _articleService.TGetWithCategory();
            return View(values);
        }
    }
}
