using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using MyBlog.BusinessLayer;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.BusinessLayer.Concrete;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.EntityFramwork;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddBusinessServices();

builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<BlogContext>().AddErrorDescriber<CustomIdentityValidator>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Add services to the container.
builder.Services.AddControllersWithViews();

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
// PROJE GENEELÝ AUTHENTÝCATÝON
builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});
builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/Login/Index";
    opts.AccessDeniedPath = new PathString("/Login/AccessDeniedPath");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Login/Pages404","?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();
var supportedCultures = new[] { "en", "fr", "es", "gr", "tr", "de" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[4]).AddSupportedCultures(supportedCultures).AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});
app.Run();
