using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Models;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("/Admin/Dashboard")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _MessageService;
        private readonly IArticleService _ArticelService;
        private readonly ICommentService _CommentService;
        private readonly IMapper _mapper;

        public DashboardController(UserManager<AppUser> userManager, IMessageService messageService, IArticleService articelService, ICommentService commentService, IMapper mapper)
        {
            _userManager = userManager;
            _MessageService = messageService;
            _ArticelService = articelService;
            _CommentService = commentService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            await LoadUserInformationAsync();
            await LoadUserInformationAsync();
            var chartData = _ArticelService.TGetChart();
            return View(_mapper.Map<List<ChartData>>(chartData));

        }
        public async Task LoadUserInformationAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = user.Name + user.SurName;
            ViewBag.ımage = user.İmageUrl;
            ViewBag.Inbox = _MessageService.GetSendandReceiverMessagenameListAllbyReceiverId(user.Id).Count();
            ViewBag.Sendbox = _MessageService.GetSendandReceiverMessagenameListAllbySenderId(user.Id).Count;
            ViewBag.Import = _MessageService.GetSendandReceiverMessagenameListAllbyİmportId(user.Id).Count;
            ViewBag.read = _MessageService.GetSendandReceiverMessagenameListAllbyReadId(user.Id).Count;
            ViewBag.blog = _ArticelService.TGetArticlesByWriter(user.Id).Count;
            ViewBag.comment = _CommentService.TGetCommentsByWriter(user.Id).Count;
        }
    }
}
