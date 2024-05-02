using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.ViewComponents.ViewComponents
{
    public class _WlNotificationComponetPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;

        public _WlNotificationComponetPartial(UserManager<AppUser> userManager, INotificationService notificationService)
        {
            _userManager = userManager;
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _notificationService.TGetListAll();
            return View(value);
        }
    }
}
