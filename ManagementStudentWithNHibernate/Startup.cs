using ManagementStudentWithNHibernate.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NHibernate.Cfg;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using ManagementStudentWithNHibernate.IRepositories;
using ManagementStudentWithNHibernate.Repositories;
using ManagementStudentWithNHibernate.Services;
using ManagementStudentWithNHibernate.IServices;
using ManagementStudentWithNHibernate.Pages.Enrollments;

namespace ManagementStudentWithNHibernate
{
    public class Startup
    {
        public static ISessionFactory sessionFactory;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            var sessionFactory = ConfigureNHibernate(Configuration.GetConnectionString("DefaultConnection"));
            services.AddSingleton(sessionFactory);

            services.AddScoped(factory => sessionFactory.OpenSession());

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            services.AddScoped<IEnrollmentService, EnrollmentService>();
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

        public static ISessionFactory ConfigureNHibernate(string connectionString)
        {
            var configuration = new Configuration();
            var configurationPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Models\\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            configuration.AddAssembly(typeof(Student).Assembly);
            return configuration.BuildSessionFactory();
        }
    }
}
