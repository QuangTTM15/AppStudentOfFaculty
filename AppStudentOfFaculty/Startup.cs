using AppStudentOfFaculty.Entity;
using AppStudentOfFaculty.Models;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace AppStudentOfFaculty
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
            services.AddControllersWithViews();
            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy",
                    builder =>
                    {
                        builder.SetIsOriginAllowed(m => true);
                        builder.WithOrigins("http://localhost:44363");
                        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                    });
            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
                options.Cookie.Name = "user_info";
            });
            services.AddDbContextPool<HungHoangContext>(options =>
                       options.UseSqlServer(Configuration.GetConnectionString("HungHoangInterConnections"), b => b.MigrationsAssembly("AppStudentOfFaculty.Entity")));

            RegisterMapper(services);
            AddServices(services);
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
            UserSession.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=SignIn}/{id?}");
            });
        }
        private static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        private static void RegisterMapper(IServiceCollection services)
        {
            Assembly mapperProfile = Assembly.Load("AppStudentOfFaculty");
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(mapperProfile);
                cfg.ValueTransformers.Add<string>(x => x ?? string.Empty);
                cfg.ValueTransformers.Add<int?>(x => x ?? 0);
                cfg.ValueTransformers.Add<bool?>(x => x ?? false);
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
