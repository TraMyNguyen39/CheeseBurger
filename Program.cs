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
using Microsoft.AspNetCore.Identity.UI.Services;
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
using System.Text;
using CheeseBurger.Model.Entities;
using CheeseBurger.Pages.User.Email;

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
service.AddScoped<IIdenCodeRespository, IdenCodeRespository>();
service.AddScoped<IIdenCodeService, IdenCodeService>();

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
                endpoints.MapPost("/Login/Validate/SuccessfulValidateEmail", async context => {
                    // Lấy dịch vụ sendmailservice
                    var sendmailservice = context.RequestServices.GetService<ISendMailService>();

					var email = context.Request.Form["email"].ToString();
                    
                    int seed = DateTime.Now.Millisecond;
                    Random rnd = new Random(seed);
                    var idcodeservice = context.RequestServices.GetService<IIdenCodeService>();
                    var listIc = idcodeservice.GetListIdenCode();
                    var idx = rnd.Next(0, listIc.Count);
                    var ic_name = listIc[idx].ICodeName;
                    var ic_id = listIc[idx].IcodeId;

                    MailContent content = new MailContent
                    {
                        To = email,
                        Subject = "Quên mật khẩu",
                        Body = "Mã xác thực của bạn là: " + ic_name + ". Mã xác thực này chỉ có hiệu lực trong vòng 1 phút !"
                    };

                    await sendmailservice.SendMail(content);
                    var accservice = context.RequestServices.GetService<IAccountService>();
                    var id = accservice.GetIDAccountByMail(email);
                    context.Session.SetInt32("IdAccCP", id);
                    context.Session.SetString("NameICodeFP", ic_name);
                    //context.Session.SetInt32("IdNP", np_id);
                    //var redirectUrl = "/Login/SuccessfulValidate?id=" + id.ToString() + "&ps=" + np_id.ToString();
                    var redirectUrl = "/Login/Validate/EnterIdenCodeFP";

                    DateTime sendTime = DateTime.Now;
                    context.Session.SetString("SendTime", sendTime.ToString());

                    context.Response.Redirect(redirectUrl);
                });
            endpoints.MapPost("/Login/SendMail/SendMailIden", async context => {
                // Lấy dịch vụ sendmailservice
                var sendmailservice = context.RequestServices.GetService<ISendMailService>();

                var email = context.Request.Form["email"].ToString();
                var name = context.Request.Form["name"].ToString();
                var phone = context.Request.Form["phone"].ToString();
                var pass = context.Request.Form["pass"].ToString();

                int seed = DateTime.Now.Millisecond;
                Random rnd = new Random(seed);
                var idcodeservice = context.RequestServices.GetService<IIdenCodeService>();
                var listIc = idcodeservice.GetListIdenCode();
                var idx = rnd.Next(0, listIc.Count);
                var ic_name = listIc[idx].ICodeName;
                var ic_id = listIc[idx].IcodeId;

                MailContent content = new MailContent
                {
                    To = email,
                    Subject = "Đăng ký tài khoản",
                    Body = "Mã xác thực của bạn là: " + ic_name + ". Mã xác thực này chỉ có hiệu lực trong vòng 1 phút !"
                };

                await sendmailservice.SendMail(content);
                context.Session.SetString("NewAccICode", ic_name);
                context.Session.SetString("NewAccEmail", email);
                context.Session.SetString("NewAccName", name);
                context.Session.SetString("NewAccPhone", phone);
                context.Session.SetString("NewAccPass", pass);
                //var redirectUrl = "/Login/EnterIdenCode?t=" + ic_id.ToString() + "&d=" + idacc.ToString() + "&c=" + idcus.ToString();
                var redirectUrl = "/Login/SendMail/EnterIdenCode";

                DateTime sendTime = DateTime.Now;
                context.Session.SetString("SendTimeCode", sendTime.ToString());
                context.Response.Redirect(redirectUrl);
            });

                endpoints.MapGet("/User/Email/MyAlternateOrder", async context =>
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

                    var model = new EmailModel(order_FoodService);
                    // Retrieve the required services
                    var sendMailService = context.RequestServices.GetService<ISendMailService>();
                    var viewRenderService = context.RequestServices.GetService<IViewRenderService>();
                    var name = context.Request.Query["name"].ToString(); // Retrieve the 'name' value from the route parameters
                    var total = context.Request.Query["total"].ToString();                    
                    var address = context.Request.Query["address"].ToString();
                    var dateTime = context.Request.Query["dateTime"].ToString();
                    var id = context.Request.Query["id"].ToString();
                    
                    int _idord = Convert.ToInt32(id);
                    int _idcusord = context.Session.GetInt32("customerID") ?? -1;
                    var li_item_email = order_FoodService.GetAllLine(_idord);
                    var item_order_email = orderService.GetOrderDetail(_idcusord, _idord);
                    // Set the 'TenNguoiNhan' property of the 'model' instance
                    model.TenNguoiNhan = name;
                    model.MaDH = id;
                    model.TongTien = item_order_email.TotalMoney.ToString("N0") + "đ";
					model.NgayDatHang = dateTime;
                    model.DiaChiGiaoHang = address;
                    model.TienShip = item_order_email.ShippingMoney.ToString("N0") + "đ";

                    var List_LineItems_Email = li_item_email;

                    string lineItemsHtml = "";
                    foreach (var item in List_LineItems_Email)
                    {					
                        lineItemsHtml += $"<li><div style='display: flex'><p style='text-transform: capitalize; margin-right: 3%'>{item.Name}</p><p> {item.Price:N0}đ x {item.Quantity}</p></div></li>";
                    }

                    model.LineItemsHtml = lineItemsHtml;

                    // Retrieve the view content
                    string viewFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Pages", "User", "Email", "Email.cshtml");
                    string emailBody = await File.ReadAllTextAsync(viewFilePath);

                    // Replace the placeholders with actual values
                    emailBody = emailBody.Replace("@Model.MaDH", model.MaDH)
                                         .Replace("@Model.TenNguoiNhan", model.TenNguoiNhan)
                                         .Replace("@Model.TongTien", model.TongTien)
                                         .Replace("@Model.NgayDatHang", model.NgayDatHang)
                                         .Replace("@Model.DiaChiGiaoHang", model.DiaChiGiaoHang)
                                         .Replace("@Model.LineItemsHtml", model.LineItemsHtml)
                                         .Replace("@Model.TienShip", model.TienShip)
                                         .Replace("@page", "")
                                         .Replace("@model EmailModel", "")
                                         .Replace("@{\r\n    ViewData[\"Title\"] = \"Email\";\r\n}", "");
                    var email = context.Session.GetString("EmailUser");

                    MailContent content = new MailContent
                    {
                        To = email,
                        Subject = "Thư cảm ơn quý khách",
                        Body = emailBody
                    };

                    // Send the email
                    await sendMailService.SendMail(content);

                    context.Response.Redirect("/User/Order/MyOrder");
                });
            });
app.Run();
