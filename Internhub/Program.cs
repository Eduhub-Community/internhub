using Internhub.Data;
using Internhub.Models.Static;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Internhub.Models;
using System.Drawing.Text;
using Internhub.Utilities;
using Internhub.Repository.IServices;
using Internhub.Repository.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add Country service
builder.Services.AddSingleton<ICountry, Country>();

//httpContect configuration
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//Configure repository
builder.Services.AddScoped<IGetInternships, InternshipServices>();


//Add postgres database service
builder.Services.AddDbContext<DataContext>(options => options.UseNpgsql(
    builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<InternhubUser, IdentityRole>(options =>
options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders().AddDefaultUI();


//builder.Services.AddIdentity<InternhubUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<DataContext>().AddDefaultUI().AddDefaultTokenProviders();

//Add service for session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//password and username settings
builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;
});
//cookies
builder.Services.ConfigureApplicationCookie(options =>
{
    // Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

    options.LoginPath = "/Identity/Account/Login";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
    options.SlidingExpiration = true;
});

// Login with google Auth
builder.Services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Google:UserSecret"];
});



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
app.MapRazorPages();
app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "area",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
