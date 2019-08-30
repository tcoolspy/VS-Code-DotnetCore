using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using dotnetPartThree.Business.Contracts;
using dotnetPartThree.Business.Services;
using dotnetPartThree.Core.Framework.Contracts;
using dotnetPartThree.Core.Models;
using dotnetPartThree.Data;
using dotnetPartThree.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace dotnetPartThree.Api
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
            // repositories
            services.AddScoped<IGenericRepository<Category, int>, GenericRepository<Category, int>>();
            services.AddScoped<IGenericRepository<Customer, string>, GenericRepository<Customer, string>>();
            services.AddScoped<IGenericRepository<Employee, int>, GenericRepository<Employee, int>>();
            services.AddScoped<IGenericRepository<Order, int>, GenericRepository<Order, int>>();
            services.AddScoped<IGenericRepository<OrderDetail, int>, GenericRepository<OrderDetail, int>>();
            services.AddScoped<IGenericRepository<Product, int>, GenericRepository<Product, int>>();
            services.AddScoped<IGenericRepository<Region, int>, GenericRepository<Region, int>>();
            services.AddScoped<IGenericRepository<Shipper, int>, GenericRepository<Shipper, int>>();
            services.AddScoped<IGenericRepository<Supplier, int>, GenericRepository<Supplier, int>>();
            services.AddScoped<IGenericRepository<Territory, int>, GenericRepository<Territory, int>>();
            
            // general services
            services.AddScoped<IGenericBusinessService<Category, int>, GenericBusinessService<Category, int>>();
            services.AddScoped<IGenericBusinessService<Customer, string>, GenericBusinessService<Customer, string>>();
            services.AddScoped<IGenericBusinessService<Employee, int>, GenericBusinessService<Employee, int>>();
            services.AddScoped<IGenericBusinessService<Order, int>, GenericBusinessService<Order, int>>();
            services.AddScoped<IGenericBusinessService<OrderDetail, int>, GenericBusinessService<OrderDetail, int>>();
            services.AddScoped<IGenericBusinessService<Product, int>, GenericBusinessService<Product, int>>();
            services.AddScoped<IGenericBusinessService<Region, int>, GenericBusinessService<Region, int>>();
            services.AddScoped<IGenericBusinessService<Shipper, int>, GenericBusinessService<Shipper, int>>();
            services.AddScoped<IGenericBusinessService<Supplier, int>, GenericBusinessService<Supplier, int>>();
            services.AddScoped<IGenericBusinessService<Territory, int>, GenericBusinessService<Territory, int>>();

            // specific services
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<NorthwindContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("NorthwindContext")));            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Northwind API", 
                    Description = "A simple API based on the Northwind Database",
                    Version = "v1"
                });
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("swagger/index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Northwind API");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
