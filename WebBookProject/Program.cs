using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using WebProject.DataAccess.Data;
using WebProject.DataAccess.Repository;
using WebProject.DataAccess.Repository.IRepository;
using DotNetEnv;
using WebProject.Utility;

Env.Load();
var clientId = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID");
var clientSecret = Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WebProjectDbContext>(options=> 
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebBookProject")));


builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<WebProjectDbContext>().AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
builder.Services.AddAuthentication().AddGoogle(option => {
    option.ClientId = clientId ?? throw new InvalidOperationException();
    option.ClientSecret = clientSecret ?? throw new InvalidOperationException();
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(100);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddRazorPages();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");

app.Run();