using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Repository;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.EntityFramwork
{
    public class EfWriterDal : GenericRepository<Writer>, IWriterDal
    {
        public int GetWriterCount()
        {
            return 0;
        }
    }
}
