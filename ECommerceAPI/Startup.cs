using ECommerceMVC.Business.IServices;
using ECommerceMVC.Business.MapperProfile;
using ECommerceMVC.Business.Services;
using ECommerceMVC.DataAccess.Data;
using ECommerceMVC.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceAPI
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ECommerceAPI", Version = "v1" });
                
            });
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductRepository, EFProductRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, EFUserRepository>();

            var connectionString = Configuration.GetConnectionString("db");

            services.AddAutoMapper(typeof(MapProfile));
            services.AddDbContext<ECommerceDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddCors(opt => opt.AddPolicy("Allow", builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyMethod();
                builder.AllowAnyHeader();

            }));
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            var scope = app.ApplicationServices.CreateScope();
            var productService = scope.ServiceProvider.GetRequiredService<IProductService>();

            app.Map("/test", xapp => xapp.Run(async x =>
            {
                var queryExist = x.Request.Query.ContainsKey("id");
                if (queryExist)
                {
                    var id = int.Parse(x.Request.Query["id"]);
                    if (await productService.IsExist(id))
                    {
                        await x.Response.WriteAsync($"Id {id} is available");
                    }
                    else
                    {
                        await x.Response.WriteAsync($"Id {id} is not available");
                    }
                }
                else
                {
                    await x.Response.WriteAsync($"There is no Id");
                }
            }));

            app.Use(async (context, next) =>
            {
                await next.Invoke();

                //Console.WriteLine(context.Request.Method);
                var isJsonContent = context.Request.HasJsonContentType();
                //Console.WriteLine(isJsonContent);
                if (isJsonContent)
                {
                    Console.WriteLine("There is json data in the incoming request");
                    //dynamic body = await context.Request.ReadFromJsonAsync<dynamic>();
                    //dynamic type = JsonConvert.DeserializeObject<dynamic>(body).ToString();
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerceAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("Allow");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
