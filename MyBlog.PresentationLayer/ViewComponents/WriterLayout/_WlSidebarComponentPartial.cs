using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.ViewComponents.ViewComponents
{
    public class _WlSidebarComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        public _WlSidebarComponentPartial(UserManager<AppUser> userManager, IArticleService articleService)
        {
            _userManager = userManager;
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.User = user.Name + user.SurName;
            ViewBag.Email=user.Email;
            ViewBag.ImageUrl = user.İmageUrl;
            ViewBag.blogs = _articleService.TGetWithCategoryByWriter(user.Id).Count();
            return View();
        }
    }
}
