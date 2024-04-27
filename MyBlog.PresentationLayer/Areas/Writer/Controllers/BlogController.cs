using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
   
    [Area("Writer")]
    [Route("/Writer/Blog")]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        public BlogController(UserManager<AppUser> userManager, IArticleService articleService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _categoryService = categoryService;
        }
        [Route("MyBlogList")]
        public async Task<IActionResult> MyBlogList()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetWithCategoryByWriter(user.Id);
            return View(values);
        }

        [Route("DeleteBlog/{id}")]
        public IActionResult DeleteBlog(int id)
        {
            _articleService.TDelete(id);

            return RedirectToAction("MyBlogList", "Blog", new { area = "Writer" });
           
        }

        [HttpGet]
        [Route("UpdateBlog/{id}")]
        public IActionResult UpdateBlog(int id)
        {
            var value = _categoryService.TGetListAll();
            List<SelectListItem> categoryValues = (from x in value
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,

                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            var values=  _articleService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        [Route("UpdateBlog/{id}")]
       public IActionResult UpdateBlog(Article article)
        {
            _articleService.TUpdate(article);
            return RedirectToAction("MyBlogList", "Blog", new { area = "Writer" });

        }
        [HttpGet]
        [Route("CreateBlog")]
        public IActionResult CreateBlog()
        {
          var value=  _categoryService.TGetListAll();
            List<SelectListItem> categoryValues = (from x in value
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,

                                                       Value = x.CategoryId.ToString()
                                                   }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        [Route("CreateBlog")]
        public async Task<IActionResult> CreateBlog(Article article)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            article.AppUserId= user.Id;
            article.CreatedDate= DateTime.Now;
            _articleService.TInsert(article);
            return RedirectToAction("MyBlogList", "Blog", new { area = "Writer" });
        }
    }
}
