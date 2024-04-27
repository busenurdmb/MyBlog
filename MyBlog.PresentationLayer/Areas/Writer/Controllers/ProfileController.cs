using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Areas.Writer.Models;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Profile")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("EditProfile")]
        public async Task<IActionResult> EditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditModelView model = new UserEditModelView();
            model.Name = values.Name;
            model.Email = values.Email;
            model.Surname = values.SurName;
            model.PhoneNumber = values.PhoneNumber;
            model.ImageUrl = values.İmageUrl;
            model.City = values.City;
            model.Username = values.UserName;
            return View(model);
        }
        [HttpPost]
        [Route("EditProfile")]
        public async Task<IActionResult> EditProfile(UserEditModelView p)
        {
      
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (p.Image != null)
            {
                var resource=Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imageName=Guid.NewGuid()+extension;
                var saveLocation = resource + "/wwwroot/images/" + imageName;
                var stream=new FileStream(saveLocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.İmageUrl = imageName;
            }
            user.SurName = p.Username;
            user.Name = p.Name;
            user.PhoneNumber = p.PhoneNumber;
            user.Email= p.Email;
            user.City = p.City;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            var result = await _userManager.UpdateAsync(user);
            if(result.Succeeded)
            {
                return RedirectToAction("MyBlogList", "Blog", new { area = "Writer" });
            }
            return View();
        }
    }
}
