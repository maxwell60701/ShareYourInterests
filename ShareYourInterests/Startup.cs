using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShareYourInterests.Application;
using ShareYourInterests.Application.Application;
using ShareYourInterests.Entity;
using ShareYourInterests.Infrastructure;
using ShareYourInterests.Infrastructure.Cache;
using ShareYourInterests.Infrastructure.Interface;
using ShareYourInterests.MVC.Filters;

namespace ShareYourInterests
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
            services.AddControllersWithViews(option=>option.Filters.Add<ActionFilter>());
            //services.AddDbContext<ShareYourInterestsDbContext>(options =>
            //    options.UseSqlServer("Data Source =.; Initial Catalog = ShareYourInterests; User = sa; Password = 123"));
            services.AddDbContext<ShareYourInterestsDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ShareYourInterestsDbContext")));
            services.AddDatabaseDeveloperPageExceptionFilter();
            AddDependencyInjection(services);
            services.AddRazorPages();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });
        }

        /// <summary>
        /// add DI
        /// </summary>
        /// <param name="services"></param>
        private void AddDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<ILoginApplication, LoginApplication>();
            services.AddScoped<ICacheContext, CacheContext>();
            services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));
        }
    }
}
