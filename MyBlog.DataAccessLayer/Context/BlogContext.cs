using Microsoft.EntityFrameworkCore;
using MyBlog.EntityLayer.Concrete;


namespace MyBlog.DataAccessLayer.Context
{
    public class BlogContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-493DFJA\\SQLEXPRESS; initial catalog=DbMyBlog;integrated security=true");
           
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Writer> Writers { get; set; }



    }
}
