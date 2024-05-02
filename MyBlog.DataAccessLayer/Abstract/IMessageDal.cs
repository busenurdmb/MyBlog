using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {
        List<Message> GetSendandReceiverMessagenameListAllbyReceiverId(int id);
       List<Message> GetSendandReceiverMessagenameListAllLast3byReceiverId(int id);
        List<Message> GetSendandReceiverMessagenameListAllbySenderId(int id);
        List<Message> GetSendandReceiverMessagenameListAllbyDraftSenderId(int id);
        List<Message> GetSendandReceiverMessagenameListAllbyİmportId(int id);
        List<Message> GetSendandReceiverMessagenameListAllbyTrashId(int id);
        List<Message> GetSendandReceiverMessagenameListAllbySpamId(int id);
        List<Message> GetSendandReceiverMessagenameListAllbyReadId(int id);
        public Message GetByIdMessageId(int id);
        Message GetDraftMessagebyİd(int? id);
        void DraftDeletebyİd(int id);
      

    }
}
