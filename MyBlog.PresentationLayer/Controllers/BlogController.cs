using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MyBlog.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
       
        public BlogController(IArticleService articleService, ICommentService commentService, ITagService tagService, IArticleTagService articletagService)
        {
            _articleService = articleService;
            _commentService = commentService;
            
        }

        public IActionResult BlogDetail(int id)
        {
            
            var values = _articleService.GetWithCategoryandUserByArticle(id);
            var comment= _commentService.TGetCommentsByBlog(id).Count();
            ViewBag.c = comment;
            return View(values);
        }
        public IActionResult BlogListByTag(int id)
        {
            // Belirli bir etikete sahip blogları getir
            var articlesWithTag = _articleService.GetArticlesByTagId(id);

            // Gerekirse bu bloglara ait diğer bilgileri de alabilirsiniz
            // Örneğin, blog yazarı bilgilerini ve kategori bilgilerini getirebilirsiniz

            return View(articlesWithTag);
        }



    }
}
