using DemoProj1.Models;
using DemoProj1.Producer;
using DemoProj1.Repositry;
using DemoProj1.Services;
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

namespace DemoProj1
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
            services.AddScoped<IStudent, StudentRepo>();
            services.AddHostedService<StudProducer>();
            services.AddScoped<IStudentServices, Service>();
            services.AddDbContext<StudentContext>(adsome=>adsome.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            services.AddScoped<IDepartment, DepartmentRepo>();
            services.AddDbContext<studentDbContext>(adsome => adsome.UseSqlServer(Configuration.GetConnectionString("DbConnection")));

            //services.AddDbContext<StudentContext>(options" "=>",options.UseSqlServer(Configuration.GetConnectionString(\"MvcMovieContext\")));
            //IServiceCollection serviceCollection = services.AddDbContext<StudentContext>(adsome => adsome.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(a=>a.AllowAnyMethod());

            app.UseCors(a => a.AllowAnyHeader());
            app.UseCors(a => a.AllowAnyOrigin());
           // app.UseCors(a => a.AllowAnyMethod());

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
