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
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        BlogContext context=new BlogContext();
        public List<Comment> GetCommentsByBlog(int id)
        {
           var values=context.Comments.Where(X=>X.ArticleId==id).ToList();
            return values;
        }
    }
}
