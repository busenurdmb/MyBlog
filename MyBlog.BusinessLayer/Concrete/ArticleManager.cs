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
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;

        public ArticleManager(IArticleDal ArticleDal)
        {
            _articleDal = ArticleDal;
        }

        public List<Article> TGetArticlesByWriter(int id)
        {
            return _articleDal.GetArticlesByWriter(id);
        }
        public void TDelete(int id)
        {
            _articleDal.Delete(id);
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public List<Article> TGetListAll()
        {
            return _articleDal.GetListAll();
        }

        public void TInsert(Article entity)
        {
          
          _articleDal.Insert(entity);
            
        }

        public void TUpdate(Article entity)
        {
            _articleDal.Update(entity);
        }

        public List<Article> TGetWithCategoryByWriter(int id)
        {
          return  _articleDal.GetWithCategoryByWriter(id);
        }

        public List<Article> TGetWithCategory()
        {
            return _articleDal.GetWithCategory();
        }

        public Article TGetWithCategoryByArticle(int id)
        {
            return _articleDal.GetWithCategoryByArticle(id);
        }
    }
}
