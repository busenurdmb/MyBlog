using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.DataAccessLayer.Context;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("/Admin/Writer")]
    public class WriterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly BlogContext _context;
        public WriterController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            // AspNetUserRoles tablosundaki verileri çekmek için bir sorgu yapalım
            var user = await _context.Users.ToListAsync();

           
            return View(user);
        }



    }
}
