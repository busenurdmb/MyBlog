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

        public IViewComponentResult Invoke(int id
            )
        {
            id = 1;
            var values = _commentService.TGetCommentsByBlog(id);
            return View(values);
        }
    }
}
