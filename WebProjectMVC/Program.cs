using Microsoft.EntityFrameworkCore;
using WebProject.DataAccess.Data;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllersWithViews();

var conn = builder.Configuration.GetConnectionString("WebProject");
builder.Services.AddDbContext<WebProjectDbContext>(options => options.UseSqlServer(conn));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
