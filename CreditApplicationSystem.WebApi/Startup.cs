using CreditApplicationSystem.ApplicationServices.API.Domain;
using CreditApplicationSystem.ApplicationServices.API.Domain.Users;
using CreditApplicationSystem.ApplicationServices.API.Validators;
using CreditApplicationSystem.ApplicationServices.Behaviours;
using CreditApplicationSystem.ApplicationServices.Components.NbpCurrencyExchangeRates;
using CreditApplicationSystem.ApplicationServices.Mappings;
using CreditApplicationSystem.DataAccess;
using CreditApplicationSystem.DataAccess.CQRS;
using CreditApplicationSystem.DataAccess.Repositories;
using CreditApplicationSystem.WebApi.Authentication;
using CreditApplicationSystem.WebApi.Middleware;
using FluentValidation.AspNetCore;
using HealthChecks.UI.Client;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using CreditApplicationSystem.DataAccess.Service;
using Microsoft.AspNetCore.Http;
using Serilog;

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
                options.AddPolicy("AllowAll", policy => policy.AllowAnyOrigin());
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));
            services.AddMediatR(typeof(ResponseBase<>));
            services.AddAutoMapper(typeof(CreditApplicationProfile).Assembly);
            services.AddTransient<IQueryExecutor, QueryExecutor>();
            services.AddTransient<ICommandExecutor, CommandExecutor>();
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddCustomerRequestValidator>());
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
            services.AddTransient<ICurrencyExchangeRatesConnector, CurrencyExchangeRatesConnector>();

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
            
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.Authority = "https://localhost:5002";
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey))
                };
            });

            services.AddAuthentication("BasicAuthentication")                
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null)
                .AddCookie();
                
            services.AddAuthorization(options => 
                options.AddPolicy("ApiScope", policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim("scope", "api1");
                }));
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

            services.AddHealthChecks();
            services.AddScoped<ErrorHandlingMiddleware>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CreditApplicationSystem.WebApi v1"));
            }
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseHttpsRedirection();
            app.UseSerilogRequestLogging();
            app.UseRouting();
            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireAuthorization("ApiScope");
                endpoints.MapHealthChecks("api/health", new HealthCheckOptions
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
        }
    }
}
