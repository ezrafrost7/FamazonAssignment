using FamazonAssignment.Models;
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
            {
                options.UseSqlServer(Configuration["ConnectionStrings:FamazonConnection"]);
            });

            //this gives the user a piece of the database that they need for interactions
            services.AddScoped<IFamazonRepository, EFFamazonRepository>();
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
                //this modifies how the url looks
                endpoints.MapControllerRoute(
                    "pagination",
                    "BookList/{page}",
                    new { Controller = "Home", action = "Index" });

                //need a default because we have edited the way the page numbers look
                endpoints.MapDefaultControllerRoute();
            });

            //this is so that we can actually create and pass the seed data
            SeedData.EnsurePopulated(app);
        }
    }
}
