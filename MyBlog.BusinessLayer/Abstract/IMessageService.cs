using MyBlog.BusinessLayer.Dto;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        public List<ListMessageDto> GetSendandReceiverMessagenameListAllbyReceiverId(int id);
        public List<ListMessageDto> GetSendandReceiverMessagenameListAllLast3byReceiverId(int id);
        public List<ListMessageDto> GetSendandReceiverMessagenameListAllbySenderId(int id);
        public List<ListMessageDto> GetSendandReceiverMessagenameListAllbyDraftSenderId(int id);
        public List<ListMessageDto> GetSendandReceiverMessagenameListAllbyİmportId(int id);
        public List<ListMessageDto> GetSendandReceiverMessagenameListAllbyTrashId(int id);
        public List<ListMessageDto> GetSendandReceiverMessagenameListAllbySpamId(int id);
        public List<ListMessageDto> GetSendandReceiverMessagenameListAllbyReadId(int id);
        ListMessageDto TGetByIddto(int id);
        public ListMessageDto GetDraftMessagebyİd(int? id);
        public void DraftDeletebyİd(int id);

    }
}
