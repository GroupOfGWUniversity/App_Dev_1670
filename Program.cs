using App_Dev_1670.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
<<<<<<< HEAD
using App_Dev_1670.Repository.IRepository;
using App_Dev_1670.Repository;
using Microsoft.AspNetCore.Identity.UI.Services;

=======
using App_Dev_1670.Models;
using App_Dev_1670.Repository.IRepository;
using App_Dev_1670.Repository;
>>>>>>> a8f2e274b68d90f2bfb690a815c8ca6508ac7621

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDatabase>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"))); // kết nối với database sử dụng lambda

<<<<<<< HEAD
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDatabase>().AddDefaultTokenProviders();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

=======
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDatabase>().AddDefaultTokenProviders();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDatabase>().AddDefaultTokenProviders();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDatabase>()
    .AddDefaultTokenProviders();
>>>>>>> a8f2e274b68d90f2bfb690a815c8ca6508ac7621

builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = $"/Identity/Account/Login";
    options.LogoutPath = $"/Identity/Account/Logout";
    options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});
builder.Services.AddRazorPages();

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
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
<<<<<<< HEAD
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");
=======
    pattern: "{area=User}/{controller=Home}/{action=Index}/{id?}");
>>>>>>> a8f2e274b68d90f2bfb690a815c8ca6508ac7621
app.Run();
