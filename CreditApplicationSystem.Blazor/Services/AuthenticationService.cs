using CreditApplicationSystem.Blazor.Helpers;
using CreditApplicationSystem.Blazor.Models;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace CreditApplicationSystem.Blazor.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IHttpService _httpService;
        private readonly NavigationManager _navigationManager;
        private readonly ILocalStorageService _localStorageService;

        public User User { get; private set; }

        public AuthenticationService(
            IHttpService httpService,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService)
        {
            _httpService = httpService;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
        }

        public async Task Initialize()
        {
            User = await _localStorageService.GetItem<User>("user");
        }

        public async Task Login(string username, string password)
        {
            User = await _httpService.Post<User>("/users/authenticate", new { username, password });
            User.AuthData = $"{username}:{password}".EncodeBase64();
            await _localStorageService.SetItem("user", User);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItem("user");
            _navigationManager.NavigateTo("login");
        }
    }
}