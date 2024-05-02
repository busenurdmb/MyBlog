using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _NotificationDal;
        public NotificationManager(INotificationDal NotificationDal)
        {
            _NotificationDal = NotificationDal;
        }
        public void TDelete(int id)
        {
            _NotificationDal.Delete(id);
        }
        public Notification TGetById(int id)
        {
            return _NotificationDal.GetById(id);
        }
        public List<Notification> TGetListAll()
        {
            return _NotificationDal.GetListAll();
        }
        public void TInsert(Notification entity)
        {
            _NotificationDal.Insert(entity);
        }
        public void TUpdate(Notification entity)
        {
            _NotificationDal.Update(entity);
        }
    }
}
