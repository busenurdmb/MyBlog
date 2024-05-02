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
    public class EfCommentDal : GenericRepository<Comment>, ICommentDal
    {
        BlogContext context=new BlogContext();

        public List<Comment> GetAllWithUserArticleComments()
        {
            var values = context.Comments.Include(x => x.AppUser).Include(x=>x.Article).ToList();
            return values;
        }

        public List<Comment> GetCommentsByBlog(int id)
        {
           var values=context.Comments.Include(x => x.AppUser).Where(X=>X.ArticleId==id).ToList();
            return values;
        }

        public List<Comment> GetCommentsByWriter(int id)
        {
            // İlk olarak, kullanıcının sahip olduğu ürünleri alıyoruz
            var productIds = context.Articles.Where(p => p.AppUserId == id).Select(p => p.ArticleId).ToList();

            // Ardından, bu ürünlerle ilişkili yorumları alıyoruz
            var comments = context.Comments.Include(x=>x.AppUser).Where(c => productIds.Contains(c.ArticleId)).Include(x=>x.Article).ToList();

            return comments;
        }
    }
}
