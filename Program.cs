using CheeseBurger;
using CheeseBurger.Helpers;
using CheeseBurger.Model;
using CheeseBurger.Repository;
using CheeseBurger.Repository.Implements;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using CheeseBurger.Service.ImplementsGetPrice;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
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
service.AddScoped<IImportOrders_IngredientsService, ImportOrders_IngredientsService>();
service.AddScoped<IImportOrders_IngredientsRepository, ImportOrders_IngredientsRepository>();
service.AddScoped<IAccountService, AccountService>();
service.AddScoped<IAccountRespository, AccountRespository>();
service.AddScoped<IFoodService, FoodService>();
service.AddScoped<IFoodRepository, FoodRepository>();
service.AddScoped<ICategoryService, CategoryService>();
service.AddScoped<ICategoryRepository, CategoryRepository>();
service.AddScoped<ICustomerService, CustomerService>();
service.AddScoped<ICustomerRespository, CustomerRespository>();
service.AddScoped<IWardService, WardService>();
service.AddScoped<IWardRespository, WardRespository>();
service.AddScoped<IDistrictService, DistrictService>();
service.AddScoped<IDistrictRespository, DistrictRespository>();
service.AddScoped<ICartService, CartService>();
service.AddScoped<ICartRepository, CartRepository>();
service.AddScoped<IReviewRepository, ReviewRepository>();
service.AddScoped<IReviewService, ReviewService>();
service.AddScoped<IStaffService, StaffService>();
service.AddScoped<IStaffRespository, StaffRespository>();
service.AddScoped<IRoleService, RoleService>();
service.AddScoped<IRoleRespository, RoleRespository>();
service.AddScoped<IOrderService, OrderService>();
service.AddScoped<IOrderRepository, OrderRepository>();
service.AddScoped<IOrder_FoodRepository, Order_FoodRepository>();
service.AddScoped<IOrder_FoodService, Order_FoodService>();
service.AddScoped<IFood_IngredientsRepository, Food_IngredientsRepository>();
service.AddScoped<IFood_IngredientsService, Food_IngredientsService>();
service.AddScoped<IRevenueRepository, RevenueRepository>();
service.AddScoped<IRevenueService, RevenueService>();

service.AddHttpClient<IFeeAPIService, FeeAPIService>(client =>
{
    client.BaseAddress = new Uri("https://online-gateway.ghn.vn/shiip/public-api/v2/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    client.DefaultRequestHeaders.Add("token", "312f0089-ed7a-11ed-8a8c-6e4795e6d902");
});

// Register your service
service.AddScoped<IFeeAPIService, FeeAPIService>();
service.AddScoped<IImportOrderService, ImportOrderService>();
service.AddScoped<IImportOrderRepository, ImportOrderRepository>();
service.AddScoped<IPartnerRespository, PartnerRespository>();
service.AddScoped<IPartnerService, PartnerService>();
service.AddScoped<ISendMailService, SendMailService>();

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
app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/Login/SuccessfulValidate1", async context => {

                    // Lấy dịch vụ sendmailservice
                    var sendmailservice = context.RequestServices.GetService<ISendMailService>();

                    MailContent content = new MailContent
                    {
                        To = "dong.huynhquang21503@gmail.com",
                        Subject = "Test",
                        Body = "Mật khẩu của bạn được đặt lại thành: 123456A@a"
                    };

                    await sendmailservice.SendMail(content);					
					context.Response.Redirect("/Login/SuccessfulValidate");
					//await context.Response.WriteAsync("Send mail");
				});
            });
app.Run();
