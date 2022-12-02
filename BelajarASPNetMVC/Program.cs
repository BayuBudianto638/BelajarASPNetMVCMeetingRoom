using BelajarASPNetMVC.Application.Services.Companies;
using BelajarASPNetMVC.ConfigProfile;
using BelajarASPNetMVC.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BelajarASPNetMVC.Application.Services.Beverages;
using BelajarASPNetMVC.Application.Services.Equipments;
using BelajarASPNetMVC.Application.Services.Layouts;
using BelajarASPNetMVC.Application.Services.Rooms;
using BelajarASPNetMVC.Application.Services.RoomSlots;

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
builder.Services.AddTransient<IRoomSlotAppService, RoomSlotAppService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
