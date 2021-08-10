using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.RepositoryModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace EmployeeManagement
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting =false);

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                  .RequireAuthenticatedUser()
                  .Build();

                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddDbContextPool<AppDbContext>(options =>
               options.UseSqlServer(@"Server=PRASANTHREDDY\PRASANTHREDDY; Database=EmployeeManagement1; User Id=sa; Password=prasanthreddy; MultipleActiveResultSets=true;")
            );

            services.AddIdentity<Employee,IdentityRole>().AddRoles<IdentityRole>()
                  .AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IDepartmentRepository, DepartmentImplementation>();
            services.AddScoped<IEmployeeRepository, EmployeeImplementation>();       
            services.AddScoped<IProjectRepository,ProjectImplementation>();
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
                app.UseStatusCodePagesWithReExecute("/Error/{0}");
            }

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot")),
                RequestPath = ""
            });

            app.UseAuthentication();

            app.UseRouting();            

            //app.UseMvcWithDefaultRoute();
           
            app.UseMvc(routes =>
            {                
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Employee}/{action=GetEmployees}/{id?}");
            });

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
