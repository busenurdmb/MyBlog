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
    public class ArticleTagManager : IArticleTagService
    {
        private readonly IArticleTagDal _articletagDal;

        public ArticleTagManager(IArticleTagDal articletagDal)
        {
            _articletagDal = articletagDal;
        }

        public List<ArticleTag> GetWithTagByArticle(int id)
        {
            return _articletagDal.GetWithTagByArticle(id);
        }

        public void TDelete(int id)
        {
            _articletagDal.Delete(id);
        }

        public ArticleTag TGetById(int id)
        {
            return _articletagDal.GetById(id);
        }

        public List<ArticleTag> TGetListAll()
        {
            return _articletagDal.GetListAll();
        }

        public void TInsert(ArticleTag entity)
        {_articletagDal.Insert(entity);
        }

        public void TUpdate(ArticleTag entity)
        {
            _articletagDal.Update(entity);
        }
    }
}
