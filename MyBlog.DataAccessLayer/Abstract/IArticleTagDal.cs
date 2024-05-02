using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Abstract
{
    public interface IArticleTagDal : IGenericDal<ArticleTag>
    {
      
        List<ArticleTag> GetWithTagByArticle(int id);

    }
}
