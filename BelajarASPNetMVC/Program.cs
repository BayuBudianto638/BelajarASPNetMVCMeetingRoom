using BelajarASPNetMVC.Application.Services.Companies;
using BelajarASPNetMVC.ConfigProfile;
using BelajarASPNetMVC.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BelajarASPNetMVC.Application.Services.Beverages;
using BelajarASPNetMVC.Application.Services.Equipments;
using BelajarASPNetMVC.Application.Services.Layouts;
using BelajarASPNetMVC.Application.Services.Rooms;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DBConnection");
builder.Services.AddDbContext<AppDbContext>(option => option.UseSqlServer(connectionString));

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new ConfigurationProfile());
});
var mapper = config.CreateMapper();

// Create DI Service
builder.Services.AddSingleton(mapper);
builder.Services.AddTransient<ICompanyAppService, CompanyAppService>();
builder.Services.AddTransient<IBeverageAppService, BeverageAppService>();
builder.Services.AddTransient<IEquipmentAppService, EquipmentAppService>();
builder.Services.AddTransient<ILayoutAppService, LayoutAppService>();
builder.Services.AddTransient<IRoomAppService, RoomAppService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
