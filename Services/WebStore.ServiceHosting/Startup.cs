using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Logger;
using WebStore.Interfaces.Services;
using WebStore.Services;
using WebStore.Services.Data;

namespace WebStore.ServiceHosting
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;
        
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddCors();
            services.AddDbContext<WebStoreContext>(options => {
                options.UseMySql(Configuration.GetConnectionString("DefaultConection"), b=>b.MigrationsAssembly("WebStore.ServiceHosting"));

            });
            services.AddTransient<WebStoreContextInitializer>();
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<WebStoreContext>()
                    .AddDefaultTokenProviders();

            services.AddSingleton<IEmployeesData, InMemoryEmployeesData>();
            services.AddScoped<IProductData, SqlProductData>();
            services.AddScoped<ICartStore, CookiesCartStore>();

            services.AddScoped<ICartService, CookieCartService>();
            services.AddScoped<IOrderService, SqlOrdersService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor > ();
        }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, WebStoreContextInitializer db, ILoggerFactory log)
        {
            log.AddLog4Net();
            Task.Run(()=>db.InitializeAsync());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseMvc();
        }
    }
}
