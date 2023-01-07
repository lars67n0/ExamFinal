using BookApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions;
using BookApp.Data.Interfaces;
using BookApp.Data.GenericService;
using System.Reflection;

namespace BookListFinal
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
            services.AddDbContext<BookListAppDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddRazorPages();
            //services.AddTransient<IGenericInterface<>, GenericService<>>();
            //services.AddTransient<IGenericInterface<Class>, GenericService<Class>>();
            //services.AddTransient<IGenericInterface<Course>, GenericService<Course>>();
            //services.AddTransient<IGenericInterface<Education>, GenericService<Education>>();
            //services.AddTransient<IGenericInterface<Teacher>, GenericService<Teacher>>();
            //services.AddTransient(typeof(IGenericInterface<Book>), typeof(GenericService<Book>));
            services.AddTransient<ITeacherInterface, TeacherService>();
            services.AddTransient<IKoordinatorInterface, KoordinatorService>();
            services.AddTransient<IClassInterface, ClassService>();
            services.AddTransient<IEducationInterface, EducationService>();
            services.AddTransient<IBookInterface, BookService>();
            services.AddTransient<ICourseInterface, CourseService>();





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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
