using CreditApplicationSystem.ApplicationServices.API.Domain;
using CreditApplicationSystem.ApplicationServices.API.Domain.Users;
using CreditApplicationSystem.ApplicationServices.Components.ScopeInformation;
using CreditApplicationSystem.ApplicationServices.Mappings;
using CreditApplicationSystem.DataAccess;
using CreditApplicationSystem.DataAccess.CQRS;
using CreditApplicationSystem.DataAccess.Repositories;
using CreditApplicationWorkflow.Mvc.Helpers;
using CreditApplicationWorkflow.Mvc.Middleware;
using HealthChecks.UI.Client;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Serilog;
using Serilog.Context;
using System.Linq;
using System.Net;
using CreditApplicationSystem.ApplicationServices.Behaviours;

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
            services.AddMediatR(typeof(ResponseBase<>));
            services.AddAutoMapper(typeof(CreditApplicationProfile).Assembly);
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();

            services.AddTransient(typeof(IRequestPreProcessor<>), typeof(PerformanceBehaviour<>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));

            services.AddDbContext<CreditApplicationWorkflowDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CreditApplicationSystemConnection")));

            services.AddDefaultIdentity<IdentityUser>(cfg => cfg.User.RequireUniqueEmail = true)
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<CreditApplicationWorkflowDbContext>();

            var authenticationSettings = new AuthenticationSettings();
            Configuration.GetSection("Authentication").Bind(authenticationSettings);
            services.AddSingleton(authenticationSettings);

            services.AddAuthentication()
                    .AddCookie()
                    .AddJwtBearer();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddControllersWithViews()
                    .AddNewtonsoftJson(cfg => cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddRazorPages()
                .AddRazorPagesOptions(opts =>
                {
                    opts.Conventions.Add(new PageRouteTransformerConvention(new KebabCaseParameterTransformer()));
                });

            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = true;
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            services.AddHealthChecks();
            services.AddScoped<IScopeInformation, ScopeInformation>();
            services.AddScoped<ErrorHandlingMiddleware>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseStatusCodePagesWithReExecute("/{0}");
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.Use(async (ctx, next) =>
            {
                IPAddress tempRemoteIpAddress = ctx.Connection.RemoteIpAddress;
                var remoteIpAddress = "";
                if (tempRemoteIpAddress != null)
                {
                    if (tempRemoteIpAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                    {
                        tempRemoteIpAddress = (await Dns.GetHostEntryAsync(tempRemoteIpAddress)).AddressList
                            .First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                    }

                    remoteIpAddress = tempRemoteIpAddress.ToString();
                }
                using (LogContext.PushProperty("IPAddress", remoteIpAddress))
                {
                    await next();
                }
            });

            app.UseSerilogRequestLogging();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=creditapplications}/{action=index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHealthChecks("/health", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
        }
    }
}
