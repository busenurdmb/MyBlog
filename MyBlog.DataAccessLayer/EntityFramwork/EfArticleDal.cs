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
    public class EfArticleDal : GenericRepository<Article>, IArticleDal
    {
        BlogContext context = new BlogContext();
        public List<Article> GetArticlesByWriter(int id)
        {
            var values = context.Articles.Where(x => x.AppUserId == id).ToList();
            return values;
        }

        public List<Article> GetWithCategory()
        {
            var values = context.Articles.Include(x => x.Category).ToList();
            return values;
        }

        public Article GetWithCategoryByArticle(int id)
        {
            var values = context.Articles.Where(x => x.ArticleId == id).Include(x => x.Category).FirstOrDefault();
            return values;
        }

        public List<Article> GetWithCategoryByWriter(int id)
        {
            var values = context.Articles.Where(x => x.AppUserId == id).Include(x=> x.Category).ToList();
            return values;
        }
    }
}
