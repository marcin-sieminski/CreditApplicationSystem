using CreditApplicationSystem.DataAccess.Entities;
using CreditApplicationSystem.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CreditApplicationSystem.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CreditApplicationController : ControllerBase
    {
        private readonly IRepository<CreditApplication>  _creditApplicationRepository;

        public CreditApplicationController(IRepository<CreditApplication> creditApplicationRepository)
        {
            _creditApplicationRepository = creditApplicationRepository;
        }


        [HttpGet]
        [Route("")]
        public IEnumerable<CreditApplication> GetAllCreditApplications() => _creditApplicationRepository.GetAll();

        [HttpGet]
        [Route("{id}")]
        public CreditApplication GetCreditApplicationById(int id)
        {
            return _creditApplicationRepository.GetById(id);
        }
    }
}
