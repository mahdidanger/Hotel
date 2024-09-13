using Hotel.Application.Services;
using Hotel.Domin.Models;
using Hotel.Infrastructure.Data;
using Hotel.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MyHotelContext>(option =>
{
    option.UseSqlServer("Data Source=.;Initial Catalog=HotelCore_DB;Integrated Security=true;TrustServerCertificate=True");
});

// Register Identity services with custom User model
builder.Services.AddIdentity<Users, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<MyHotelContext>()
    .AddDefaultTokenProviders();

builder.Services.AddRazorPages();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddScoped<IReservationService, ReservationService>();


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login"; 
    
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    // بررسی درخواست‌های به مسیرهای "/Admin"
    if (context.Request.Path.StartsWithSegments("/Admin"))
    {
        // بررسی اینکه آیا کاربر وارد شده است یا خیر
        if (!context.User.Identity.IsAuthenticated)
        {
            // اگر کاربر وارد نشده است، به صفحه لاگین هدایت شود
            context.Response.Redirect("/Identity/Account/Login");
        }
        else
        {
            // بررسی اینکه کاربر مقدار IsModir دارد یا خیر و آیا true است
            var isModirClaim = context.User.FindFirst(c => c.Type == "IsModir")?.Value;
            if (string.IsNullOrEmpty(isModirClaim) || !bool.Parse(isModirClaim))
            {
                // اگر کاربر مدیر نیست، به صفحه لاگین هدایت شود
                context.Response.Redirect("/Identity/Account/Login");
            }
        }
    }

    await next.Invoke();
});


app.MapRazorPages();

app.Run();
