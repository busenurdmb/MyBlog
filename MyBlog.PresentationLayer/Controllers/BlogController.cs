using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;

        public BlogController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult BlogDetail(int id)
        {
            id = 1;
            var values = _articleService.TGetById(id);

            ViewBag.createdData = values.CreatedDate;
            ViewBag.title = values.Title;
            var values2 = _articleService.TGetWithCategoryByArticle(id);

            ViewBag.categoryName = values2.Category.CategoryName;
            ViewBag.Detail=values2.Detail;
            return View();
        }
    }
}
