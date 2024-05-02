using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.ViewComponents.ViewComponents
{
    public class _MailLayoutSidebarComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _MessageService;

        public _MailLayoutSidebarComponent(UserManager<AppUser> userManager, IMessageService MessageService)
        {
            _userManager = userManager;
            _MessageService = MessageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.user = user.Name;
            ViewBag.email = user.Email;
            ViewBag.ImageUrl = user.İmageUrl;
            var Inbox = _MessageService.GetSendandReceiverMessagenameListAllbyReceiverId(user.Id).Count();
            ViewBag.Inbox = Inbox;

            var Sendbox = _MessageService.GetSendandReceiverMessagenameListAllbySenderId(user.Id).Count;
            ViewBag.Sendbox = Sendbox;

            var Draft = _MessageService.GetSendandReceiverMessagenameListAllbyDraftSenderId(user.Id).Count;
            ViewBag.Draft = Draft;

            var Import = _MessageService.GetSendandReceiverMessagenameListAllbyİmportId(user.Id).Count;
            ViewBag.Import = Import;

            var Trash = _MessageService.GetSendandReceiverMessagenameListAllbyTrashId(user.Id).Count;
            ViewBag.Trash = Trash;

            var Junk = _MessageService.GetSendandReceiverMessagenameListAllbySpamId(user.Id).Count;
            ViewBag.Junk = Junk;
            return View();
        }
    }
}
