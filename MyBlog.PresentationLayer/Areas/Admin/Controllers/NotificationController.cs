using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;


namespace MyNotification.PresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("/Admin/Notification")]
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

        [Route("DeleteNotification/{id}")]
        public IActionResult DeleteNotification(int id)
        {
            _notificationService.TDelete(id);

            return RedirectToAction("MyNotificationList", "Notification", new { area = "Writer" });

        }

        [HttpGet]
        [Route("UpdateNotification/{id}")]
        public IActionResult UpdateNotification(int id)
        {
            
            var values = _notificationService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateNotification/{id}")]
        public IActionResult UpdateNotification(Notification notification)
        {
            notification.IsRead = "false";
            _notificationService.TUpdate(notification);
            return RedirectToAction("MyNotificationList", "Notification", new { area = "Admin" });

        }
        [HttpGet]
        [Route("CreateNotification")]
        public IActionResult CreateNotification()
        {
           
            return View();
        }

        [HttpPost]
        [Route("CreateNotification")]
        public async Task<IActionResult> CreateNotification(Notification notification)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
          
            notification.Date = DateTime.Now;
            notification.IsRead = "false";
            _notificationService.TInsert(notification);
            return RedirectToAction("MyNotificationList", "Notification", new { area = "Admin" });
        }
        [HttpGet]
        [Route("Aktif/{id}")]
        public ActionResult Aktif(int id)
        {
            var a = _notificationService.TGetById(id);


            a.IsRead = "true";
            _notificationService.TUpdate(a);

            return RedirectToAction("Index");
        }
        [Route("Pasif/{id}")]
        public ActionResult Pasif(int id)
        {
            var a = _notificationService.TGetById(id);


            a.IsRead = "false";
            _notificationService.TUpdate(a);

            return RedirectToAction("Index");
        }
    }
}
