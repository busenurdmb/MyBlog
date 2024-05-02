using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.ViewComponents.ViewComponents
{
    public class _WlProfileComponetPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _WlProfileComponetPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.user = user.Name+" "+ user.SurName;
            ViewBag.email = user.Email;
            ViewBag.ImageUrl = user.İmageUrl;
            return View();
        }
    }
}
