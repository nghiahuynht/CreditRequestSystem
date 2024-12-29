using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.IService;
using DAL.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rotativa.AspNetCore;
using WebApp.ExcelHelper;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
     
            // Đăng ký IHttpContextAccessor để có thể sử dụng trong các lớp khác
            services.AddHttpContextAccessor();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddDbContext<EntityDataContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));
            services.AddDistributedMemoryCache(); // Cấu hình bộ nhớ để lưu session
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(1440); // Thời gian session hết hạn
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true; // Bắt buộc cookie để hoạt động
            });
            services.AddTransient<ICommonService, CommonService>();
            services.AddTransient<IUserInfoService, UserInfoService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ICreditRequestService, CreditRequestService>();
            services.AddTransient<IAttachFileService, AttachFileService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IProjectFinancialSummarService, ProjectFinancialSummarService>();
            services.AddTransient<IProjectFinancialDetailService, ProjectFinancialDetailService>();
            services.AddTransient<IPermissionService, PermissionService>();
            services.AddTransient<IPaymentRequestService, PaymentRequestService>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}/{id2?}/{id3?}");
            });
            RotativaConfiguration.Setup((IHostingEnvironment)env);
        }
    }
}
