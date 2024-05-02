using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.BusinessLayer.Concrete;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.EntityFramwork;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategroyDal>();
            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleDal, EfArticleDal>();
            services.AddScoped<ISocialMediaService, SocialMediaManager>();
            services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();


            services.AddScoped<IArticleTagService, ArticleTagManager>();
            services.AddScoped<IArticleTagDal, EfArticleTagDal>();
            services.AddDbContext<BlogContext>();
           
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessageDal, EfMessageDal>();

            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<INotificationDal, EfNotificationDal>();

            services.AddScoped<ITagService, TagManager>();
            services.AddScoped<ITagDal, EfTagDal>();


        }
    }
}
