using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyBlog.EntityLayer.Concrete;


namespace MyBlog.DataAccessLayer.Context
{
    public class BlogContext:IdentityDbContext<AppUser,AppRole,int>
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
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<Notification> Notifications { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Message>()
                .HasOne(x => x.Sender)
                .WithMany(y => y.SenderMail)
                .HasForeignKey(z => z.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.Receiver)
                .WithMany(y => y.ReceiverMail)
                .HasForeignKey(z => z.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);
        }



    }
}
