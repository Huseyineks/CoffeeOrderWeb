using CoffeeOrderWeb.BusinessLogicLayer.DTOs;
using CoffeeOrderWeb.BusinessLogicLayer.Validators;
using CoffeeOrderWeb.DataAccesLayer.Data;
using CoffeeOrderWeb.EntityLayer.Model;
using FluentValidation;
using CoffeeOrderWeb.BusinessLogicLayer.Abstract;
using CoffeeOrderWeb.BusinessLogicLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using CoffeeOrderWeb.DataAccesLayer.Abstract;
using CoffeeOrderWeb.DataAccesLayer.Concrete;
using Microsoft.Build.Framework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddIdentity<AppUser, AppUserRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddScoped<IValidator<RegisterUserDTO>, RegisterUserValidator>();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IOrderDetailsService, OrderDetailsService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService,PaymentService>();
builder.Services.AddScoped<IMenuService, MenuService>();


builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index";
    
    
});
//builder.Services.AddScoped<IOrderDetailsService,OrderDetailsService>();
//builder.Services.AddScoped<IOrderService,OrderService>();
//builder.Services.AddScoped<IPaymentService,PaymentService>();
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "MyArea",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.Run();
