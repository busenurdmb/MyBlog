using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")]
    [Route("/Writer/Comment")]
    public class CommentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICommentService _commentService;

        public CommentController(UserManager<AppUser> userManager, ICommentService commentService)
        {
            _userManager = userManager;
            _commentService = commentService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _commentService.TGetCommentsByWriter(user.Id);
            return View(values);
        }
    }
}
