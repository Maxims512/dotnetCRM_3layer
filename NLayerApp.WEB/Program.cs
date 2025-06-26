using Microsoft.EntityFrameworkCore;
using NLayerApp.BLL.Interfaces;
using NLayerApp.BLL.Services;
using NLayerApp.DAL.EF;
using NLayerApp.DAL.Interfaces;
using NLayerApp.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<MobileContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService, OrderService>();


builder.Services.AddAutoMapper(typeof(BLLMappingProfile), typeof(MappingProfile));


builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();