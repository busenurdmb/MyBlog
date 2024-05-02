using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Authorize(Roles ="Writer")]
    [Area("Writer")]
    [Route("/Writer/Blog")]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;
        private readonly IArticleTagService _articletagService;
        public BlogController(UserManager<AppUser> userManager, IArticleService articleService, ICategoryService categoryService, ITagService tagService, IArticleTagService articletagService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _categoryService = categoryService;
            _tagService = tagService;
            _articletagService = articletagService;
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
        [HttpGet]
        [Route("CreateTagBlog/{id}")]
        public IActionResult CreateTagBlog(int id)
        {
            var value = _tagService.TGetListAll();
            ViewBag.ArticleId = id;

            // Mevcut bloğa zaten ekli olan etiketleri al
            var existingTags = _articletagService.GetWithTagByArticle(id);

            // Bloğa ekli olan etiketlerin TagId'lerini bir listede sakla
            var existingTagIds = existingTags.Select(t => t.TagId).ToList();

            // Tüm etiketleri alırken, zaten ekli olanları seçili olarak işaretle
            List<SelectListItem> TagValues = (from x in value
                                              select new SelectListItem
                                              {
                                                  Text = x.TagTitle,
                                                  Value = x.TagId.ToString(),
                                                  Selected = existingTagIds.Contains(x.TagId) // Bu etiket zaten ekli mi?
                                              }).ToList();

            ViewBag.TagValues = TagValues;
            return View();
        }

        [HttpPost]
        [Route("CreateTagBlog/{id}")]
        public async Task<IActionResult> CreateTagBlog(List<int> SelectedTags, int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (SelectedTags != null && SelectedTags.Any())
            {
                foreach (var tagId in SelectedTags)
                {
                    var articleTag = new ArticleTag
                    {
                        ArticleId = id,
                        TagId = tagId
                    };
                    _articletagService.TInsert(articleTag);
                }
            }

            return RedirectToAction("MyBlogList", "Blog", new { area = "Writer" });
        }
    }
}
