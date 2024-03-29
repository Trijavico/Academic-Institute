﻿using Institute.DAL.Interfaces;
using Institute.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Institute.DAL.Context;
using Institute.BLL.Contracts;
using Institute.BLL.Services;

namespace Institute.Web
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
            // Context //
            services.AddDbContext<InstituteContext>(options => options.UseSqlServer(Configuration.GetConnectionString("InstituteContext")));

            //Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();

            //Services(BL)//
            services.AddTransient<IProfessorService, ProfessorService>();
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
            }
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