using CreditApplicationSystem.DataAccess;
using CreditApplicationSystem.DataAccess.Entities;
using CreditApplicationSystem.DataAccess.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CreditApplicationWorkflow.Mvc
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
            services.AddDbContext<CreditApplicationWorkflowDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CreditApplicationSystemConnection")));

            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<CreditApplicationWorkflowDbContext>();
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepository<CreditApplication>), typeof(CreditApplicationRepository));

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=CreditApplication}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
