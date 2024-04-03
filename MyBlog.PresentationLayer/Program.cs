using MyBlog.BusinessLayer.Abstract;
using MyBlog.BusinessLayer.Concrete;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.EntityFramwork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICategoryDal, EfCategroyDal>();
builder.Services.AddScoped<IArticleService, ArticleManager>();
builder.Services.AddScoped<IArticleDal, EfArticleDal>();
// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
