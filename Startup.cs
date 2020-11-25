using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Market.Model;
using Market.Model.DB;
using Market.Model.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Market
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
            services.AddRazorPages();
            services.AddSingleton<Group_Method>();
            services.AddSingleton<MItem>();

            services.AddScoped<GroupsRepository>();
            services.AddScoped<ItemsRepository>();


            services.AddMvc().AddRazorPagesOptions(options =>
            {
                //options.RootDirectory = "/Pages";
                options.Conventions.AddPageRoute("/Home", string.Empty);
            });

            //services.AddDbContext<StoreDb>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("SqlConn"));
            //});
            services.AddDbContext<StoreDb>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SqlConn")));
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
