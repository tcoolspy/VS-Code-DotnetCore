using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mySolutionOne.Api.Data;

namespace mySolutionOne.Api
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
            //services.AddDbContext<StudentContext>();
            //TODO: put this in a config file
            var contextRoot = GetApplicationRoot();
            //services.AddDbContext<StudentContext>(options => options.UseSqlite("Data Source=students.db"));
            services.AddDbContext<StudentContext>(options => options.UseSqlite($"Filename={contextRoot}students.db"));

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Training API", Version = "v1" });
            });

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Training API");
                c.RoutePrefix = string.Empty;
            });

            // DefaultFilesOptions defaultFile = new DefaultFilesOptions();
            // defaultFile.DefaultFileNames.Clear();
            // defaultFile.DefaultFileNames.Add("index.html");
            
            // app.UseDefaultFiles(defaultFile);
            // app.UseStaticFiles();

            app.UseHttpsRedirection();
            app.UseMvc();
        }


        public string GetApplicationRoot()
        {
            var path = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var pathSections = path.Split("/", StringSplitOptions.RemoveEmptyEntries).ToList();
            var returnPath = "/";
            foreach (var section in pathSections)
            {
                if (section != "bin")
                    {
                        returnPath += section;
                        returnPath += "/";
                    }
                else break;
            }

            return returnPath;
        }
    }
}
