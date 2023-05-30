using DataAccessLayer;
using DataAccessLayer.Repositories.CartRepo;
using DataAccessLayer.Repositories.CategoryRepo;
using DataAccessLayer.Repositories.ItemRepo;
using DataAccessLayer.Repositories.ItemSizePriceOrderRepo;
using DataAccessLayer.Repositories.ItemSizePriceRepo;
using DataAccessLayer.Repositories.OrderRepo;
using DataAccessLayer.Repositories.PermissionRepo;
using DataAccessLayer.Repositories.PictureRepo;
using DataAccessLayer.Repositories.RolePermissionRepo;
using DataAccessLayer.Repositories.RoleRepo;
using DataAccessLayer.Repositories.SizeRepo;
using DataAccessLayer.Repositories.StatusRepo;
using DataAccessLayer.Repositories.UserRepo;
using DataAccessLayer.Repositories.WrapperRepo;
using Microsoft.EntityFrameworkCore;
using Services.Services.AuthService;
using Services.Services.CartServices;
using Services.Services.CategoryServices;
using Services.Services.HomeServices;
using Services.Services.ItemServices;
using Services.Services.ItemSizePriceOrderServices;
using Services.Services.ItemSizePriceServices;
using Services.Services.OrderServices;
using Services.Services.PermissionService;
using Services.Services.PictureServices;
using Services.Services.RoleService;
using Services.Services.SizeServices;
using Services.Services.StatusServices;
using Services.Services.UserPermissionService;
using Services.Services.UserRoleService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("DataAccessLayer")));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});

builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);

//Repositories

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IItemSizePriceOrderRepository, ItemSizePriceOrderRepository>();
builder.Services.AddScoped<IItemSizePriceRepository, ItemSizePriceRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IPictureRepository, PictureRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ISizeRepository, SizeRepository>();
builder.Services.AddScoped<IStatusRepository, StatusRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

//Services

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IHomeService, HomeService>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemSizePriceOrderService, ItemSizePriceOrderService>();
builder.Services.AddScoped<IItemSizePriceService, ItemSizePriceService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IPictureService, PictureService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ISizeService, SizeService>();
builder.Services.AddScoped<IStatusService, StatusService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();

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
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Portal}/{action=LogIn}/{id?}");

app.Run();
