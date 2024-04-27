using MyBlog.EntityLayer.Concrete;


namespace MyBlog.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        List<Article> GetArticlesByWriter(int id);
        List<Article> GetWithCategoryByWriter(int id);
        List<Article> GetWithCategory();
        Article GetWithCategoryByArticle(int id);

    }
}
