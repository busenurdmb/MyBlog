using MyBlog.EntityLayer.Concrete;


namespace MyBlog.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        List<Article> GetArticlesByWriter(int id);
        List<Article> GetWithCategoryByWriter(int id);
        List<Article> GetWithCategory();
        List<Article> GetWithCategorylast6();
        Article GetWithCategoryByArticle(int id);
        Article GetWithCategoryandUserByArticle(int id);
        List<Article> GetArticlesByTagId(int tagId);
         List<object> GetChart();

    }
}
