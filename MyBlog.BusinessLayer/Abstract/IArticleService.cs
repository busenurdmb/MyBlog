using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
   public interface IArticleService:IGenericService<Article>
    {
        List<Article> TGetArticlesByWriter(int id);
        List<Article> TGetWithCategoryByWriter(int id);
        List<Article> TGetWithCategory();
        Article TGetWithCategoryByArticle(int id);
    }
}
