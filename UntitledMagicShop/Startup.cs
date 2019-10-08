using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using UntitledMagicShop.Core.Application_Services;
using UntitledMagicShop.Core.Application_Services_Impl;
using UntitledMagicShop.Core.Domain_Services;
using UntitledMagicShop.Core.Entities;
using UntitledMagicShop.Infrastructure.SQLData;
using UntitledMagicShop.Infrastructure.SQLData.Repos;

namespace UntitledMagicShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<UntitledMagicShopAppContext>(opt =>
                {
                    opt.UseSqlite("Data Source=worldOfOzWebshop.db");
                });
            }
            else
            {
                services.AddDbContext<UntitledMagicShopAppContext>(opt =>
                {
                    opt.UseSqlServer(Configuration.GetConnectionString("defaultConnection"));
                });
            }

            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<UntitledMagicShopAppContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                    DBInitializer.SeedDB(ctx);
                }
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<UntitledMagicShopAppContext>();
                    ctx.Database.EnsureCreated();
                    

                }
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}