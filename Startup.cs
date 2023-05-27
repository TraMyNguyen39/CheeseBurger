using CheeseBurger.Helpers;
using CheeseBurger.Service.Implements;
using CheeseBurger.Service;
using Microsoft.Extensions.Configuration;

//namespace CheeseBurger
//{
//    public class Startup
//    {
//        IConfiguration _configuration;
//        public Startup(IConfiguration configuration)
//        {
//            _configuration = configuration;
//        }

//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddOptions();                                         // Kích hoạt Options
//            var mailsettings = _configuration.GetSection("MailSettings");  // đọc config
//            services.Configure<MailSettings>(mailsettings);  // đăng ký để Inject
//            services.AddTransient<ISendMailService, SendMailService>();
//        }

//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }

//            app.UseRouting();

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapGet("/testmail", async context => {

//                    // Lấy dịch vụ sendmailservice
//                    var sendmailservice = context.RequestServices.GetService<ISendMailService>();

//                    MailContent content = new MailContent
//                    {
//                        To = "vothedat1102@gmail.com",
//                        Subject = "Kiểm tra thử",
//                        Body = "<p><strong>Xin chào vo the dat</strong></p>"
//                    };

//                    await sendmailservice.SendMail(content);
//                    await context.Response.WriteAsync("Send mail");
//                });
//            });
//        }
//    }
//}
