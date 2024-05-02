using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Models;

namespace MyBlog.PresentationLayer.Areas.AdminWriter.Controllers
{
    [Authorize(Roles = "Admin,Writer")]
    [Area("AdminWriter")]
    [Route("/AdminWriter/Message")]
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _MessageService;
        private readonly IMapper _mapper;
        public MessageController(IMessageService MessageService, UserManager<AppUser> userManager, IMapper mapper)
        {
            _MessageService = MessageService;
            _userManager = userManager;
            _mapper = mapper;
        }

        //Mesaj Gönderme
        [HttpGet]
        [Route("Compose/{id?}")]
        public async Task<IActionResult> Compose(int? id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var draft = _MessageService.GetDraftMessagebyİd(id);
            if (draft != null)
            {
                var draftMessage = new ListMessageModel()
                {
                    MessageId = draft.MessageId,
                    MailContent = draft.MailContent,
                    MailSubject = draft.MailSubject,
                    ReceiverId = draft.ReceiverId,
                    ReceiverEmail = _userManager.Users
      .Where(x => x.Id == draft.ReceiverId).FirstOrDefault().Email,



                };

                return View(draftMessage);
            }
            return View();


        }


        [HttpPost]
        [Route("Compose")]

        public async Task<JsonResult> Compose(ListMessageModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var p = _mapper.Map<Message>(model);

            p.SenderId = user.Id;
            var receiverUser = await _userManager.FindByEmailAsync(model.ReceiverEmail);
            if (receiverUser != null)
            {
                p.ReceiverId = receiverUser.Id;
            }
            p.MailDate = DateTime.Now;
            p.MailTime = DateTime.Now.TimeOfDay;
            if (p.ReceiverId == user.Id)
            {
                ViewBag.EMessageError = "Kendinize Message gönderemezsiniz";

            }
            p.Sender = null;
            p.Receiver = null;
            p.MessageId = 0;
            _MessageService.TInsert(p);
            _MessageService.DraftDeletebyİd(model.MessageId);
            return Json("Ok");


        }

        //Taslak Oluşturma

        [HttpPost]
        [Route("DraftAdd")]

        public async Task<JsonResult> DraftAdd(ListMessageModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var p = _mapper.Map<Message>(model);

            p.SenderId = user.Id;
            var receiverUser = await _userManager.FindByEmailAsync(model.ReceiverEmail);
            if (receiverUser != null)
            {
                p.ReceiverId = receiverUser.Id;
            }
            p.MailDate = DateTime.Now;
            p.MailTime = DateTime.Now.TimeOfDay;
            if (p.ReceiverId == user.Id)
            {
                ViewBag.EMessageError = "Kendinize Message gönderemezsiniz";

            }
            p.IsDraft = true;
            p.Sender = null;
            p.Receiver = null;
            //Message p = new Message();
            //p.SenderId = user.Id;

            //var receiverUser = await _userManager.FindByEMessageAsync(model.ReceiverEMessage);
            //if (receiverUser != null)
            //{
            //    p.ReceiverId = receiverUser.Id;
            //}
            //p.MessageContent = model.MessageContent;
            //p.MessageSubject = model.MessageSubject;
            //p.MessageDate = DateTime.Now;
            //p.MessageTime = DateTime.Now.TimeOfDay;
            //p.IsDraft = true;
            //p.IsImportant = false;
            //p.IsJunk = false;
            //p.IsRead = false;
            //p.IsTrash = false;

            //if (p.ReceiverId == user.Id)
            //{
            //    return Json(new { error = "Kendinize Message gönderemezsiniz" });
            //}

            _MessageService.TInsert(p);
            return Json("Ok");
        }

        //Mesaj Okuma
        [HttpGet]
        [Route("ReadMail/{id}")]

        public async Task<IActionResult> ReadMail(int id)
        {
            var Message = _MessageService.TGetById(id);
            Message.IsRead = true;
            _MessageService.TUpdate(Message);

            var values = _MessageService.TGetByIddto(id);
            var p = _mapper.Map<ListMessageModel>(values);
            return View(p);
        }
        //Gelen Mesajlar 
        [HttpGet]
        [Route("Inbox")]
        public async Task<IActionResult> Inbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _MessageService.GetSendandReceiverMessagenameListAllbyReceiverId(user.Id);
            return View(_mapper.Map<List<ListMessageModel>>(value));
        }
        //Gönderilen Mesajlar
        [HttpGet]
        [Route("Sendbox")]

        public async Task<IActionResult> Sendbox()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _MessageService.GetSendandReceiverMessagenameListAllbySenderId(user.Id);
            return View(_mapper.Map<List<ListMessageModel>>(value));
        }
        //Taslaklar
        [Route("Draft")]

        public async Task<IActionResult> Draft()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _MessageService.GetSendandReceiverMessagenameListAllbyDraftSenderId(user.Id);
            return View(_mapper.Map<List<ListMessageModel>>(value));
        }

        //Önemli Mesajlar
        [HttpGet]
        [Route("Important")]

        public async Task<IActionResult> Important()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _MessageService.GetSendandReceiverMessagenameListAllbyİmportId(user.Id);
            return View(_mapper.Map<List<ListMessageModel>>(value));
        }

        //Yıldızla
        [HttpGet]
        [Route("MakeImportant/{id}")]
        public async Task<IActionResult> MakeImportant(int id, string redirectAction)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var important = _MessageService.TGetById(id);

            if (important.IsImportant)
            {
                important.IsImportant = false;
            }
            else
            {
                important.IsImportant = true;
            }
            _MessageService.TUpdate(important);
            return RedirectToAction(redirectAction);
        }
        //Spamlı Mesajlar
        [HttpGet]
        [Route("Junk")]

        public async Task<IActionResult> Junk()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _MessageService.GetSendandReceiverMessagenameListAllbySpamId(user.Id);
            return View(_mapper.Map<List<ListMessageModel>>(value));
        }
        //Spamla
        [HttpPost]
        [Route("MakeJunk/{id}")]

        public async Task<JsonResult> MakeJunk(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var Junk = _MessageService.TGetById(id);

            Junk.IsJunk = true;
            _MessageService.TUpdate(Junk);
            return Json("Ok");
        }
        //Çöp Kutusu
        [HttpGet]
        [Route("Trash")]

        public async Task<IActionResult> Trash()
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var value = _MessageService.GetSendandReceiverMessagenameListAllbyTrashId(user.Id);
            return View(_mapper.Map<List<ListMessageModel>>(value));
        }
        //Çöp Yap
        [HttpPost]
        [Route("Trash/{id}")]

        public async Task<IActionResult> Trash(int id, string redirectAction)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var trash = _MessageService.TGetById(id);


            trash.IsTrash = true;
            _MessageService.TUpdate(trash);
            return Json("Ok");
        }
        //Sil
        [HttpPost]
        [Route("Delete/{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            _MessageService.TDelete(id);
            return Json("Ok");
        }
        public async Task LoadUserInformationAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = user.Name + user.SurName;
            ViewBag.ımage = user.İmageUrl;
            ViewBag.Inbox = _MessageService.GetSendandReceiverMessagenameListAllbyReceiverId(user.Id).Count();
            ViewBag.Sendbox = _MessageService.GetSendandReceiverMessagenameListAllbySenderId(user.Id).Count;
            ViewBag.Import = _MessageService.GetSendandReceiverMessagenameListAllbyİmportId(user.Id).Count;
            ViewBag.read = _MessageService.GetSendandReceiverMessagenameListAllbyReadId(user.Id).Count;
        }
        [HttpGet]
        [Route("datepicker")]

        public async Task<IActionResult> datepicker()
        {
            await LoadUserInformationAsync();

            return View();
        }
    }
}
