using Microsoft.EntityFrameworkCore;
using OfficeApp;
using OfficeApp.Services.Abstraction;
using OfficeApp.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDBContext>(options =>

    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(x => 
{
    x.Password.RequireDigit = true;
    x.Password.RequiredLength = 8;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = true;
    x.Password.RequireLowercase = false;
    
})
    .AddEntityFrameworkStores<AppDBContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP requet pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Serve files from wwwroot (static assets)
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
