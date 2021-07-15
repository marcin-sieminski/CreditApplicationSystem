using CreditApplicationSystem.Blazor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CreditApplicationSystem.Blazor.Services
{
    public class CreditApplicationsService : ICreditApplicationsService
    {
        private readonly IHttpService _httpService;

        public CreditApplicationsService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public Task<IEnumerable<CreditApplication>> GetAll()
        {
            return _httpService.Get<IEnumerable<CreditApplication>>("/creditapplications");
        }

        public Task<CreditApplication> GetById(int id)
        {
            return _httpService.Get<CreditApplication>($"/creditapplications/{id}");
        }

        public async Task<int> Create(CreditApplication creditApplication)
        {
            var result = await _httpService.Post<CreditApplication>("/creditapplications", creditApplication);
            return result.Id;
        }

        public async Task<int> Delete(int id)
        {
            await _httpService.Delete($"/creditapplications/{id}");
            return id;
        }

        public async Task<int> Update(CreditApplication creditApplication)
        {
            var result = await _httpService.Put<CreditApplication>($"/creditapplications/{creditApplication.Id}", creditApplication);
            return result.Id;
        }
    }
}