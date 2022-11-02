using Demo.Data;
using Demo.IReposotories;
using Demo.IServices;
using Demo.Models;
using Demo.Repositories;
using Demo.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo
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
            services.AddControllers();
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(Configuration.GetConnectionString("appConn")));
            services.AddScoped<IBaseRepository<User>, UserRepository>();
            services.AddScoped<IBaseService<User>, UserService>();

            services.AddScoped<IBaseRepository<Category>, CategoryRepository>();
            services.AddScoped<IBaseService<Category>, CategoryService>();

            services.AddScoped<IBaseRepository<Product>, ProductRepository>();
            services.AddScoped<IBaseService<Product>, ProductService>();
            services.AddScoped<ICategoryService, ProductService>();
            services.AddScoped<ISupplierService, ProductService>();

            services.AddScoped<IBaseRepository<Supplier>, SupplierRepository>();
            services.AddScoped<IBaseService<Supplier>, SupplierService>();
            //services.AddScoped<>
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
