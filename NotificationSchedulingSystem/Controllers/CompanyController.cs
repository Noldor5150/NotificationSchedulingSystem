using API.Errors;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly ICompanyNumberDublicateCheckService _numberCheckService;

        public CompanyController(ICompanyService companyService, ICompanyNumberDublicateCheckService numberCheckService)
        {
            _companyService = companyService;
            _numberCheckService = numberCheckService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyToReturnDTO>> GetCompanyNotifications(Guid id)
        {
            var result = await _companyService.GetCompanyNotificationsByIdAsync(id);

            if (result == null)
            {
                return BadRequest(new ApiResponse(400));
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CompanyToReturnDTO>> CreateCompany(AddCompanyDTO company)
        {
            if (await _numberCheckService.CheckCompanyNumberlExistsAsync(company.CompanyNumber))
            {
                return new BadRequestObjectResult(new ApiValidationErrorResponse { Errors = new[] { "Company code in use it is" } });
            }

            var result = await _companyService.CreateCompanyAsync(company);

            if (result == null)
            {
                return BadRequest(new ApiResponse(400));
            }

            return Ok (result);
        }
     
    }
}
