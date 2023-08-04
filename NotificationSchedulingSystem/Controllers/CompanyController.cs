using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _repository;
        private readonly ICompanyService _service;
        public CompanyController(ICompanyRepository repository, ICompanyService service)
        {
            _repository = repository;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Company>>>  GetCompanies()
        {
           var companies = await _repository.GetCompaniesAsync();
           return Ok(companies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetCompanyData(Guid id) 
        {
            return await _service.GetCompanyByIdAsync(id);
        }

        [HttpPost ("{id}")]
        public async Task<ActionResult<CompanyToReturnDTO>> CreateCompany(AddCompanyDTO company)
        {
            return await _service.CreateCompanyAsync(company);
        }
     
    }
}
