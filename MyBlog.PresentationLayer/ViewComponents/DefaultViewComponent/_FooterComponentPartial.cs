using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponent
{
    public class _FooterComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;
        public _FooterComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.GetWithCategorylast6();
            return View(values);
        }
    }
}
