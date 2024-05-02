using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("/Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICommentService _commentService;

        public CommentController(UserManager<AppUser> userManager, ICommentService commentService)
        {
            _userManager = userManager;
            _commentService = commentService;
        }
        [HttpGet]
        [Route("Index")]

        public IActionResult Index()
        {
            var values = _commentService.GetAllWithUserArticleComments();
            return View(values);
        }
        [HttpGet]
        [Route("Aktif/{id}")]
        public ActionResult Aktif(int id)
        {
            var trash = _commentService.TGetById(id);


            trash.Status = true;
            _commentService.TUpdate(trash);
          
            return RedirectToAction("Index");
        }
        [Route("Pasif/{id}")]
        public ActionResult Pasif(int id)
        {
            var trash = _commentService.TGetById(id);


            trash.Status = false;
            _commentService.TUpdate(trash);

            return RedirectToAction("Index");
        }
    }
}
