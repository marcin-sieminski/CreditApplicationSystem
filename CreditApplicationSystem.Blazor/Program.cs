using CreditApplicationSystem.Blazor.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CreditApplicationSystem.Blazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<IUserService, UserService>()
                .AddScoped<ICreditApplicationService, CreditApplicationService>()
                .AddScoped<ICustomerService, CustomerService>()
                .AddScoped<IHttpService, HttpService>()
                .AddScoped<ILocalStorageService, LocalStorageService>();

            builder.Services.AddScoped(x => {
                var apiUrl = new Uri(builder.Configuration["apiUrl"]);
                return new HttpClient() { BaseAddress = apiUrl };
            });

            var host = builder.Build();

            var authenticationService = host.Services.GetRequiredService<IAuthenticationService>();
            await authenticationService.Initialize();

            await host.RunAsync();
        }
    }
}
