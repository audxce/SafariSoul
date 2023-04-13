using Microsoft.EntityFrameworkCore;
using SafariSoul.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();     //new
builder.Services.AddDbContext<ZooDbContext>(options => options.UseMySql(builder.Configuration["ConnectionStrings:DefaultConnection"],ServerVersion.AutoDetect(builder.Configuration["ConnectionStrings:DefaultConnection"])));

builder.Services.AddDistributedMemoryCache();   //new

builder.Services.AddSession(options =>  //new
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();   //new

app.MapRazorPages();
app.MapDefaultControllerRoute();    //new

app.Run();

