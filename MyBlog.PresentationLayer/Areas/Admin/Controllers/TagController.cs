using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("/Admin/Tag")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }

        [Route("tagList")]
        public async Task<IActionResult> tagList()
        {
            
            var values = _tagService.TGetListAll();
            return View(values);
        }

        [Route("Deletetag/{id}")]
        public IActionResult Deletetag(int id)
        {
            _tagService.TDelete(id);

            return RedirectToAction("tagList", "Tag", new { area = "Admin" });

        }

        [HttpGet]
        [Route("Updatetag/{id}")]
        public IActionResult Updatetag(int id)
        {

            var values = _tagService.TGetById(id);
            return View(values);
        }

        [HttpPost]
        [Route("Updatetag/{id}")]
        public IActionResult Updatetag(Tag tag)
        {
            
            _tagService.TUpdate(tag);
            return RedirectToAction("tagList", "Tag", new { area = "Admin" });


        }
        [HttpGet]
        [Route("Createtag")]
        public IActionResult Createtag()
        {

            return View();
        }

        [HttpPost]
        [Route("Createtag")]
        public async Task<IActionResult> Createtag(Tag tag)
        {
           
            
            _tagService.TInsert(tag);
            return RedirectToAction("tagList", "Tag", new { area = "Admin" });

        }


    }
}
