using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sion.BurgerBackend.BusinessLogic.Entities;
using Sion.BurgerBackend.DataAccess;

namespace Sion.BurgerBackend.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BurgerBackendDbContext>(opt => opt.UseInMemoryDatabase("BurgerBackend"));

            services.AddControllers();
            services.AddHealthChecks();
            services.AddHttpContextAccessor();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/healthcheck", async context =>
                {
                    await context.Response.WriteAsync("ok");
                });
            });

            var context = serviceProvider.GetService<BurgerBackendDbContext>()!;
            AddTestDataToDb(context);
        }

        private static void AddTestDataToDb(BurgerBackendDbContext db)
        {
            db.Restaurants.Add(new Restaurant("Burger palace", new List<Burger>{
                new Burger("Ultra burg"),
                new Burger("Plant king")
            }));

            db.Restaurants.Add(new Restaurant("Every day burger", new List<Burger>{
                new Burger("Top bacon"),
                new Burger("Double burn")
            }));

            db.SaveChanges();
        }
    }
}