using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("/Admin/Statistic")]
    public class StatisticController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _MessageService;
        private readonly IArticleService _ArticelService;
        private readonly ICommentService _CommentService;
        private readonly INotificationService _notificaitonService;
        private readonly ITagService _TagService;
        private readonly ICategoryService _categoryService;

        public StatisticController(UserManager<AppUser> userManager, IMessageService messageService, IArticleService articelService, ICommentService commentService, INotificationService notificaitonService, ITagService tagService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _MessageService = messageService;
            _ArticelService = articelService;
            _CommentService = commentService;
            _notificaitonService = notificaitonService;
            _TagService = tagService;
            _categoryService = categoryService;
        }
        [HttpGet]
        [Route("Index")]

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = user.Name + user.SurName;
            ViewBag.ımage = user.İmageUrl;

            ViewBag.blog = _ArticelService.TGetListAll().Count;
            ViewBag.comment = _CommentService.TGetListAll().Count;
            ViewBag.mesaj = _MessageService.TGetListAll().Count;
            ViewBag.notificaiton = _notificaitonService.TGetListAll().Count;
            ViewBag.Tags = _TagService.TGetListAll().Count;
            ViewBag.category = _categoryService.TGetListAll().Count;

            var Tag = _TagService.TGetListAll();
            ViewBag.firsttag = Tag.First().TagTitle;
            ViewBag.lastTag = Tag.Last().TagTitle;

           

            var articles = _ArticelService.TGetListAll();
            ViewBag.firstArticle = articles.First().Title;
            ViewBag.lastArticle = articles.Last().Title;

            var categories = _categoryService.TGetListAll();
            ViewBag.firstc = categories.First().CategoryName;
            ViewBag.lastc = categories.Last().CategoryName;

            return View();
        }
    }
}
