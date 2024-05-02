using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.ViewComponents.CommentViewComponent
{
    public class _CommentAddByBlogComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;
      

        public _CommentAddByBlogComponentPartial(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            
            ViewBag.Id = id;
            
            return View();
        }
    }
}
