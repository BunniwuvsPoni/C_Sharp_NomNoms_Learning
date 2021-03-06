using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NomNoms.Data;

namespace NomNoms
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
            services.AddDbContextPool<NomNomsDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("NomNomsDb"));
            });
            
            //  Singleton is only used for development or test as it is not thread safe and will postively, result in data corruption in production.
            //  Use Scoped for production, it scopes changes to each individual http request and allows the software to collect all the changes.
            services.AddScoped<IRestaurantData, SqlRestaurantData>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseNodeModules(env);
            app.UseCookiePolicy();

            app.UseMvc();

            //  If nothing else above this is activated and returns a response
            app.Use(SayHelloMiddleware);
        }

        private RequestDelegate SayHelloMiddleware(
                                    RequestDelegate arg)
        {
            return async ctx =>
            {
                if( ctx.Request.Path.StartsWithSegments("/hello"))
                { 
                    await ctx.Response.WriteAsync("Hello, World!");
                }
                else
                {
                    await ctx.Response.WriteAsync("Not here at Hello, World!");
                }
            };
        }
    }
}
