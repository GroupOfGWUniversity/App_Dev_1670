using App_Dev_1670.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using App_Dev_1670.Models;
<<<<<<< Updated upstream
=======
using App_Dev_1670.Repository.IRepository;
using App_Dev_1670.Repository;
using Microsoft.AspNetCore.Identity.UI.Services;
using App_Dev_1670.Utility;
>>>>>>> Stashed changes

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDatabase>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING"))); // kết nối với database sử dụng lambda

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDatabase>().AddDefaultTokenProviders();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDatabase>().AddDefaultTokenProviders();
<<<<<<< Updated upstream
//builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
=======
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
    

})
>>>>>>> Stashed changes
    .AddEntityFrameworkStores<ApplicationDatabase>()
                .AddDefaultTokenProviders();


builder.Services.AddTransient<IEmailSender, EmailSender>();



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

app.UseAuthorization();
app.UseAuthentication();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
