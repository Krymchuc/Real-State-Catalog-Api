using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
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
using AutoMapper;
using Real_State_Catalog_Server.Service.IService;
using Real_State_Catalog_Server.Service;
using Microsoft.AspNetCore.Identity;
using DataAccess.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Real_State_Catalog.Shared.Repository.IRepository;
using Real_State_Catalog.Shared.Repository;

namespace Real_State_Catalog_Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders().AddDefaultUI();


            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ApplicationDbContext")));
            services.AddScoped<IDbInitializer, DbInitializer>();
            services.AddScoped<IFileUpload, FileUpload>();


            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IRoomOrderDetailsRepository, RoomOrderDetailsRepository>();
            services.AddScoped<IImagesRepository, ImagesRepository>();
            services.AddScoped<IAmenityRepository, AmenityRepository>();
            services.AddHttpContextAccessor();
            services.Configure<RazorPagesOptions>(options => options.RootDirectory = "/Pages");


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IDbInitializer dbInitializer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            dbInitializer.Initialize();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                //endpoints.MapFallbackToPage("/_Host");
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
