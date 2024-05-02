using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponent
{
    public class _TagBlogComponentPartial : ViewComponent
    {
        private readonly IArticleTagService _articleTagService;

        public _TagBlogComponentPartial(IArticleTagService articleService)
        {
            _articleTagService = articleService;
        }

        public IViewComponentResult Invoke(int id)
        {

            var values = _articleTagService.GetWithTagByArticle(id);
            return View(values);
        }
    }
}
