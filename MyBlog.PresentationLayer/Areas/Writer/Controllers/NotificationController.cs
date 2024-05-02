using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    [Route("/Writer/Notification")]
    public class NotificationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly INotificationService _notificationService;

        public NotificationController(UserManager<AppUser> userManager, INotificationService notificationService)
        {
            _userManager = userManager;
            _notificationService = notificationService;
        }

        [Route("MyNotificationList")]
        public async Task<IActionResult> MyNotificationList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _notificationService.TGetListAll();
            return View(values);
        }
    }
}
