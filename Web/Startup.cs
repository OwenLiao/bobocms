using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using DAL;
using Microsoft.EntityFrameworkCore;


using System;
using Microsoft.AspNetCore.Http;

namespace Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Add framework services.
            services.AddMvc();


            services.AddAuthorization();

            // Add framework services.
            services.AddDbContext<MyDbContext>(options =>
          
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            // Repositories
     
            services.AddScoped<ICategoryService,CategoryService>()
                    .AddScoped<IManagerRoleService, ManagerRoleService>()
                    .AddScoped<ISysChannelService, SysChannelService>()
                    .AddScoped<IManagerRoleValueService, ManagerRoleValueService>()
                    .AddScoped<IManagerService, ManagerService>()
                    .AddScoped<IArticleService, ArticleService>();


            // Automapper Configuration
            //  AutoMapperConfiguration.Configure();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.CookieHttpOnly = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseSession();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}");
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


            DbInitializer.Initialize(app.ApplicationServices);
        }
    }
}
