using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.WriterCommentPartial
{
    public class _WriterInfoByBlogComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _WriterInfoByBlogComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int id)
        {

            var values = _articleService.GetWithCategoryandUserByArticle(id);
            return View(values);
        }
    }
}
