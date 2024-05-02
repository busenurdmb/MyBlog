using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Models;

namespace MyBlog.PresentationLayer.ViewComponents.ViewComponents
{
    public class _WlMessageComponetPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;
        private readonly IMapper _mapper;

        public _WlMessageComponetPartial(UserManager<AppUser> userManager, IMessageService messageService, IMapper mapper)
        {
            _userManager = userManager;
            _messageService = messageService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _messageService.GetSendandReceiverMessagenameListAllLast3byReceiverId(user.Id);
            var model = _mapper.Map<List<ListMessageModel>>(value);
            return View(model);
        }
    }
}
