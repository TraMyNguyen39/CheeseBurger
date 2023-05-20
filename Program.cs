﻿using CheeseBurger;
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
                        To = "nguyentramy19112003@gmail.com",
                        Subject = "CheeseBurger",
                        Body = "Mật khẩu của bạn được đặt lại thành: 123456A@a"
                    };

                    await sendmailservice.SendMail(content);					
					context.Response.Redirect("/Login/SuccessfulValidate");
					//await context.Response.WriteAsync("Send mail");
				});

				endpoints.MapGet("/User/MyOrder", async context => {
					// Lấy dịch vụ sendmailservice
					var sendmailservice = context.RequestServices.GetService<ISendMailService>();

					MailContent content = new MailContent
					{
						To = "nguyentramy19112003@gmail.com",
						Subject = "CheeseBurger",
						Body = "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <title>Cảm ơn quý khách đã mua hàng của chúng tôi</title>\r\n    <style>\r\n        body {\r\n            font-family: Arial, sans-serif;\r\n            margin: 0;\r\n            padding: 20px;\r\n        }\r\n\r\n        h1 {\r\n            color: #333;\r\n        }\r\n\r\n        p {\r\n            color: #666;\r\n            line-height: 1.5;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <h1>Cảm ơn quý khách đã mua hàng của chúng tôi</h1>\r\n    <p>Xin chào,</p>\r\n    <p>Chúng tôi xin gửi lời cảm ơn chân thành đến quý khách đã mua hàng tại cửa hàng của chúng tôi. Đây là một email tự động để xác nhận đơn hàng của quý khách.</p>\r\n    <p>Chúng tôi đã nhận được đơn hàng của quý khách và đang tiến hành xử lý. Chúng tôi sẽ gửi thông tin về việc giao hàng đến quý khách trong thời gian sớm nhất.</p>\r\n    <p>Nếu quý khách có bất kỳ câu hỏi nào về đơn hàng hoặc dịch vụ của chúng tôi, xin vui lòng liên hệ với chúng tôi qua địa chỉ email hoặc số điện thoại được cung cấp bên dưới.</p>\r\n    <p>Chúng tôi rất trân trọng sự tin tưởng và ủng hộ của quý khách.</p>\r\n    <p>Trân trọng,</p>\r\n    <p>Cửa hàng của chúng tôi</p>\r\n</body>\r\n</html>"
					};

					await sendmailservice.SendMail(content);
					context.Response.Redirect("/User/Menu");
					//await context.Response.WriteAsync("Send mail");
				});
			});
app.Run();
