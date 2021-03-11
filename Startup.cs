using FamazonAssignment.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamazonAssignment
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //we add a setter to this
        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //we have to add the database service to this
            services.AddDbContext<FamazonDbContext>(options =>

                options.UseSqlite(Configuration["ConnectionStrings:FamazonConnection"]));
            

            //this gives the user a piece of the database that they need for interactions
            services.AddScoped<IFamazonRepository, EFFamazonRepository>();

            //adding razor page functionality
            services.AddRazorPages();

            //session capabilities
            services.AddDistributedMemoryCache();
            services.AddSession();

            //stuff for cart editing
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //this modifies how the url looks and the different ways you can type in the url to get to a page
                endpoints.MapControllerRoute("catPage",
                    "{category}/P{pageNum:int}",
                    new { Controller = "Home", action = "Index"}
                    );

                endpoints.MapControllerRoute("cats",
                    "{category}",
                    new { Controller = "Home", action = "Index", page = 1}
                    );

                endpoints.MapControllerRoute(
                    "pagination",
                    "BookList/P{pageNum}",
                    new { Controller = "Home", action = "Index" });

                //need a default because we have edited the way the page numbers look
                endpoints.MapDefaultControllerRoute();

                endpoints.MapRazorPages();
            });

            //this is so that we can actually create and pass the seed data
            SeedData.EnsurePopulated(app);
        }
    }
}
