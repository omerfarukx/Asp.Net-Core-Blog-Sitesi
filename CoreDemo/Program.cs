using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>(x=>
{
    x.Password.RequireUppercase = false;
    x.Password.RequireNonAlphanumeric = false;
})
    .AddEntityFrameworkStores<Context>();
builder.Services.AddMvc();
builder.Services.AddAuthentication(
        CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.ExpireTimeSpan= TimeSpan.FromMinutes(100);
        x.AccessDeniedPath = new PathString("/Login/AccesDenied");
        x.LoginPath = "/Login/Index";
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/ErrorPage/Error1", "?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
  );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
