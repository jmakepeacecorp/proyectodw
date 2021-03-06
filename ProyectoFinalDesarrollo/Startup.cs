using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProyectoFinalDesarrollo.Connection;
using ProyectoFinalDesarrollo.Mapper;
using ProyectoFinalDesarrollo.Mappers;
using ProyectoFinalDesarrollo.Repository;
using ProyectoFinalDesarrollo.Repository.iRepository;

namespace ProyectoFinalDesarrollo
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
            services.AddDbContext<conn>(Options => Options.UseSqlServer(Configuration.GetConnectionString("ConnDBSQL")));
            services.AddScoped<iEVentaRepository, EVentaRepository>();
            services.AddScoped<iClienteRepository, ClienteRepository>();
            services.AddScoped<iProductoRepository, ProductoRepository>();
            //AutoMapper, para crear la relaci�n entre Modelos y DTOs
            services.AddAutoMapper (typeof(EVentaMappers));
            services.AddAutoMapper(typeof(ClienteMappers));
            services.AddAutoMapper(typeof(ProductoMappers));
            services.AddControllersWithViews();
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
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
