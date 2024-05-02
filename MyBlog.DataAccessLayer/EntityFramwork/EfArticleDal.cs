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

        public List<Article> GetArticlesByTagId(int tagId)
        {
            // Burada, ArticleTag tablosundan belirli bir etiket ID'sine sahip olan tüm Article ID'lerini alabiliriz
            var articleIdsWithTag = context.ArticleTags
                .Where(at => at.TagId == tagId)
                .Select(at => at.ArticleId)
                .ToList();

            // Şimdi, bu Article ID'leri kullanarak ilgili makaleleri alabiliriz
            var articlesWithTag = context.Articles.Include(x=>x.Category)
                .Where(a => articleIdsWithTag.Contains(a.ArticleId))
                .ToList();

            return articlesWithTag;
        }

        public List<Article> GetArticlesByWriter(int id)
        {
            var values = context.Articles.Where(x => x.AppUserId == id).ToList();
            return values;
        }

        public List<object> GetChart()
        {
            var query = from article in context.Articles
                        join category in context.Categories
                        on article.CategoryId equals category.CategoryId
                        group category by category.CategoryName into g
                        select new
                        {
                            CategoryName = g.Key,
                            BlogCount = g.Count()
                        };

            return query.ToList<object>();
        }

        public List<Article> GetWithCategory()
        {
            var values = context.Articles.Include(x => x.Category).ToList();
            return values;
        }

        public Article GetWithCategoryandUserByArticle(int id)
        {
            var values = context.Articles.Include(x => x.Category).Where(x=>x.ArticleId==id).Include(x=>x.AppUser).FirstOrDefault();
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

        public List<Article> GetWithCategorylast6()
        {
            var last6Articles = context.Articles
                                .OrderByDescending(a => a.ArticleId)
                                .Take(6)
                                .ToList();

            return last6Articles;
        }

        //public List<Article> GetWithTagByArticle(int id)
        //{
        //    var values = context.Articles.Include(x => x.ArticleTags).ToList();
        //    return values;
        //}
    }
}
