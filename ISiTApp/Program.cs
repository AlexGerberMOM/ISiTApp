using ISiTApp.Infrastructure;
using ISiTApp.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(
    opts =>
    {
        opts.ModelBinderProviders.Insert(1, new CustomDateTimeModelBinderProvider());
    });
builder.Services.AddTransient<ITimeService, SimpleTimeService>();

/*
builder.Services.Configure<MvcViewOptions>(options => {
    options.ViewEngines.Clear();
    options.ViewEngines.Insert(0, new CustomViewEngine());
});
*/

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
    pattern: "{controller=Home}/{action=Index}/{id?}",
    constraints: new { id = new IntRouteConstraint() }
);
app.MapControllerRoute(
    name: "name_age",
    pattern: "{controller}/{action}/{name}/{age}"
);

app.MapControllerRoute(
    name: "Account",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

// маршрут для области account
app.MapAreaControllerRoute(
    name: "account_area",
    areaName: "account",
    pattern: "profile/{controller=Home}/{action=Index}/{id?}");
app.MapAreaControllerRoute(
    name: "devviews_area",
    areaName: "devviews",
    pattern: "devviews/{controller=Home}/{action=Index}/{id?}");

app.Run();
public interface ITimeService
{
    string Time { get; }
}
public class SimpleTimeService : ITimeService
{
    public string Time => DateTime.Now.ToString("hh:mm:ss");
}