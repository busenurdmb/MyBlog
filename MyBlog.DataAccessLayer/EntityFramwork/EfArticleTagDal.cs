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
    public class EfArticleTagDal : GenericRepository<ArticleTag>, IArticleTagDal
    {
        BlogContext context = new BlogContext();

        public List<ArticleTag> GetWithTagByArticle(int id)
        {
            var values = context.ArticleTags.Include(X=>X.Tag).Where(X=>X.ArticleId==id).ToList();
            return values;
        }
    }
}
