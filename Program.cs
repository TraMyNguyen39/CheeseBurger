using CheeseBurger;
using CheeseBurger.Helpers;
using CheeseBurger.Model;
using CheeseBurger.Pages;
using CheeseBurger.Pages.User;
using CheeseBurger.Repository;
using CheeseBurger.Repository.Implements;
using CheeseBurger.Service;
using CheeseBurger.Service.Implements;
using CheeseBurger.Service.ImplementsGetPrice;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RazorLight;
using System;
using System.Dynamic;
using System.Net.Http.Headers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
service.AddScoped<IViewRenderService, ViewRenderService>();
service.AddSingleton<ICompositeViewEngine, CompositeViewEngine>();
service.AddSingleton<ITempDataProvider, CookieTempDataProvider>();

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
				endpoints.MapGet("/Login/SuccessfulValidate1", async context =>
				{
					// Lấy dịch vụ sendmailservice
					var sendmailservice = context.RequestServices.GetService<ISendMailService>();

					MailContent content = new MailContent
					{
						To = "vothedatdavid@gmail.com",
						Subject = "Test",
						Body = "Mật khẩu của bạn được đặt lại thành: 123456A@a"
					};

					await sendmailservice.SendMail(content);
					context.Response.Redirect("/Login/SuccessfulValidate");
					//await context.Response.WriteAsync("Send mail");
				});
                endpoints.MapGet("/User/MyAlternateOrder", async context =>
                {
                    // Inside your method or class constructor
                    var serviceProvider = context.RequestServices;

                    var orderService = serviceProvider.GetService<IOrderService>();
                    var order_FoodService = serviceProvider.GetService<IOrder_FoodService>();
                    var cartService = serviceProvider.GetService<ICartService>();
                    var wardService = serviceProvider.GetService<IWardService>();
                    var districtService = serviceProvider.GetService<IDistrictService>();
                    var staffService = serviceProvider.GetService<IStaffService>();
                    var foodService = serviceProvider.GetService<IFoodService>();
                    var reviewService = serviceProvider.GetService<IReviewService>();
                    var hostingEnvironment = serviceProvider.GetService<IWebHostEnvironment>();
                    var customerService = serviceProvider.GetService<ICustomerService>();
                    var categoryService = serviceProvider.GetService<ICategoryService>();

                    var model = new EmailModel();

                    // Retrieve the required services
                    var sendMailService = context.RequestServices.GetService<ISendMailService>();
                    var viewRenderService = context.RequestServices.GetService<IViewRenderService>();


                    model.MaDH = "#123";
                    model.TenNguoiNhan = "KKKK"; // Retrieve the value from the session
                    model.TongTien = "69.000đ";
                    model.NgayDatHang = "24/5/2020";
                    model.DiaChiGiaoHang = "23 Nguyễn Văn Cừ";

                    // Retrieve the view content
                    string viewFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Pages", "User", "Email.cshtml");
                    string emailBody = await File.ReadAllTextAsync(viewFilePath);

                    // Replace the placeholders with actual values
                    emailBody = emailBody.Replace("@Model.MaDH", model.MaDH)
                                         .Replace("@Model.TenNguoiNhan", model.TenNguoiNhan)
                                         .Replace("@Model.TongTien", model.TongTien)
                                         .Replace("@Model.NgayDatHang", model.NgayDatHang)
                                         .Replace("@Model.DiaChiGiaoHang", model.DiaChiGiaoHang);

                    MailContent content = new MailContent
                    {
                        To = "vothedatdavid@gmail.com",
                        Subject = "Thư cảm ơn quý khách",
                        Body = emailBody
                    };

                    // Send the email
                    await sendMailService.SendMail(content);

                    context.Response.Redirect("/User/MyOrder");
                });
                
            });
app.Run();
