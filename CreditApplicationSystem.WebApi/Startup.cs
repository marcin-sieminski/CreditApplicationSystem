using CreditApplicationSystem.ApplicationServices.API.Domain;
using CreditApplicationSystem.ApplicationServices.API.Validators;
using CreditApplicationSystem.ApplicationServices.Components.NbpCurrencyExchangeRates;
using CreditApplicationSystem.ApplicationServices.Mappings;
using CreditApplicationSystem.DataAccess;
using CreditApplicationSystem.DataAccess.CQRS;
using CreditApplicationSystem.DataAccess.Repositories;
using CreditApplicationSystem.WebApi.Authentication;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.IO;

namespace CreditApplicationSystem.WebApi
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });

            services.AddMediatR(typeof(ResponseBase<>));
            services.AddAutoMapper(typeof(CreditApplicationProfile).Assembly);
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddCustomerRequestValidator>());
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            services.AddTransient<ICurrencyExchangeRatesConnector, CurrencyExchangeRatesConnector>();

            services.AddDbContext<CreditApplicationWorkflowDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("CreditApplicationSystemConnection")));

            services.AddDefaultIdentity<IdentityUser>(cfg => cfg.User.RequireUniqueEmail = true)
                .AddEntityFrameworkStores<CreditApplicationWorkflowDbContext>();

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null)
                .AddCookie()
                .AddJwtBearer();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddControllers()
                .AddNewtonsoftJson(cfg => cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.Configure<RouteOptions>(options =>
            {
                options.AppendTrailingSlash = true;
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Credit Application System", Version = "v1", Description = "Workflow system for financial institutions." });
                var filePath = Path.Combine(AppContext.BaseDirectory, "CreditApplicationSystem.WebApi.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CreditApplicationSystem.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
