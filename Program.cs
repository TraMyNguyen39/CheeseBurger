using CheeseBurger.Model;
using CheeseBurger.Repository;
using CheeseBurger.Repository.Implements;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var service = builder.Services;
service.AddDbContext<CheeseBurgerContext>(option =>
{
	var connectionString = builder.Configuration.GetConnectionString("Default");
	option.UseSqlServer(connectionString);
	//option.UseSqlServer(connectionString);
});

service.AddSession();
service.AddScoped<IIngredientsService, IngredientsService>();
service.AddScoped<IIngredientsRespository, IngredientsRespository>();
service.AddScoped<IAccountService, AccountService>();
service.AddScoped<IAccountRespository, AccountRespository>();
service.AddScoped<IFoodService, FoodService>();
service.AddScoped<IFoodRepository, FoodRepository>();
service.AddScoped<ICategoryService, CategoryService>();
service.AddScoped<ICategoryRepository, CategoryRepository>();
service.AddScoped<ICustomerService, CustomerService>();
service.AddScoped<ICustomerRespository, CustomerRespository>();
service.AddScoped<IAddressService, AddressService>();
service.AddScoped<IAddressRespository, AddressRespository>();
service.AddScoped<IWardService, WardService>();
service.AddScoped<IWardRespository, WardRespository>();
service.AddScoped<IDistrictService, DistrictService>();
service.AddScoped<IDistrictRespository, DistrictRespository>();
service.AddScoped<ICartService, CartService>();
service.AddScoped<ICartRepository, CartRepository>();


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

app.MapRazorPages();
app.UseSession();
app.Run();
