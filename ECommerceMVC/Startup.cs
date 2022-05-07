using ECommerceMVC.Business.IServices;
using ECommerceMVC.Business.MapperProfile;
using ECommerceMVC.Business.Services;
using ECommerceMVC.DataAccess.Data;
using ECommerceMVC.DataAccess.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceMVC
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
            services.AddControllersWithViews();
            services.AddScoped<IProductService , ProductService>();
            services.AddScoped<ICategoryService , CategoryService>();
            services.AddScoped<IProductRepository, EFProductRepository>();

            var connectionString = Configuration.GetConnectionString("db");

            services.AddDbContext<ECommerceDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddAutoMapper(typeof(MapProfile));
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Users/Login";
                        options.AccessDeniedPath = "/Users/AccessDenied";
                    });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "{category}/Page{page}",
                    defaults: new { controller = "Home", action = "Index", page = 1, category = "" });
                
                endpoints.MapControllerRoute(
                   name: "",
                   pattern: "{category}/Page{page}",
                   defaults: new { controller = "Home", action = "Index", page = 1, category = "" });

                endpoints.MapControllerRoute(
                    name: "",
                    pattern: "Page{page}",
                    defaults:new {controller = "Home", action = "Index", page =1 });                

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
