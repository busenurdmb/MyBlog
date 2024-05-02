using Microsoft.EntityFrameworkCore;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.Repository;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.EntityFramwork
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        BlogContext context = new BlogContext();
        public void DraftDeletebyİd(int id)
        {
            var deleteDraft = context.Message.FirstOrDefault(x => x.MessageId == id && x.IsDraft);
            if (deleteDraft != null)
            {
                context.Message.Remove(deleteDraft);
                context.SaveChanges();
            }
        }

        public Message GetDraftMessagebyİd(int? id)
        {
            var draft = context.Message.FirstOrDefault(x => x.MessageId == id && x.IsDraft);
            return draft;
        }

        public List<Message> GetSendandReceiverMessagenameListAllbyDraftSenderId(int id)
        {
            var values = context.Message.Include(x => x.Receiver).Where(y => y.SenderId == id && y.IsDraft && !y.IsTrash && !y.IsJunk).Include(y => y.Sender).ToList();
            return values;
        }

        public List<Message> GetSendandReceiverMessagenameListAllbyReadId(int id)
        {
            var values = context.Message.Include(x => x.Receiver).Where(y => y.ReceiverId == id && !y.IsDraft && !y.IsTrash && !y.IsJunk && !y.IsRead).Include(y => y.Sender).ToList();
            return values;
        }

        public List<Message> GetSendandReceiverMessagenameListAllbyReceiverId(int id)
        {
            var values = context.Message.Include(x => x.Receiver).Where(y => y.ReceiverId == id && !y.IsDraft && !y.IsTrash && !y.IsJunk).Include(y => y.Sender).ToList();
            return values;
        }

        public List<Message> GetSendandReceiverMessagenameListAllbySenderId(int id)
        {
            var values = context.Message.Include(x => x.Receiver).Where(y => y.SenderId == id && !y.IsDraft && !y.IsTrash && !y.IsJunk).Include(y => y.Sender).ToList();
            return values;
        }

        public List<Message> GetSendandReceiverMessagenameListAllbySpamId(int id)
        {
            var values = context.Message.Include(x => x.Receiver).Where(x => x.ReceiverId == id && x.IsJunk && !x.IsTrash && !x.IsDraft).Include(y => y.Sender).ToList();
            return values;
        }

        public List<Message> GetSendandReceiverMessagenameListAllbyTrashId(int id)
        {
            var values = context.Message.Include(x => x.Receiver).Where(y => y.SenderId == id || y.ReceiverId == id).Where(x => x.IsTrash == true).Include(y => y.Sender).ToList();
            return values;
        }

        public List<Message> GetSendandReceiverMessagenameListAllbyİmportId(int id)
        {
            var values = context.Message.Include(x => x.Receiver).Where(y => (y.SenderId == id || y.ReceiverId == id) && !y.IsDraft && !y.IsTrash && y.IsImportant).Include(y => y.Sender).ToList();
            return values;
        }

        public Message GetByIdMessageId(int id)
        {
            var values = context.Message.Include(X => X.Sender).Where(x => x.MessageId == id).Include(x => x.Receiver).FirstOrDefault();
            return values;
        }

        public  List<Message> GetSendandReceiverMessagenameListAllLast3byReceiverId(int id)
        {
            var values =  context.Message.Include(x => x.Receiver).Where(y => y.ReceiverId == id && !y.IsDraft && !y.IsTrash && !y.IsJunk).Include(y => y.Sender).OrderByDescending(a => a.MessageId)
                                .Take(3).ToList();

            return values;
        }

        
    }
}
