using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.CommentViewComponent
{
    public class _CommentListByBlogComponentPartial:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _CommentListByBlogComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            
            var values = _commentService.TGetCommentsByBlog(id);
            ViewBag.count=values.Count;
            return View(values);
        }
    }
}
