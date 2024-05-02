using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Models;

namespace MyBlog.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Succeeded)
            {
               return RedirectToAction("Index", "Default");
            }
            else
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult AccessDeniedPath()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Pages404(int code)
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
