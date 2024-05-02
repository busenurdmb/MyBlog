using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commmetService, UserManager<AppUser> userManager)
        {
            _commentService = commmetService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<JsonResult> Add(Comment comment)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            comment.AppUserId = user.Id;
            comment.CreatedDatae = DateTime.Now;
            comment.Status = true;
           _commentService.TInsert(comment);
            return Json("Ok");
        }



         

    }

}



