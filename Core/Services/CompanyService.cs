using Core.Entities;
using Core.Interfaces;
using Shared.DTOs;

namespace Core.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _repository;
        private readonly IScheduleService _scheduleService;

        public CompanyService(ICompanyRepository repository, IScheduleService scheduleService) 
        {
            _repository = repository;
            _scheduleService = scheduleService;
        }

        public async Task<CompanyToReturnDTO> CreateCompanyAsync(AddCompanyDTO company)
        {
            var schedule = _scheduleService.CreateSchedule(company);
            var newCompany = new Company
            {
                Id = company.Id,
                CompanyNumber = company.CompanyNumber,
                CompanyType = company.CompanyType,
                Market = company.Market,
                Schedule = schedule,
            };

            await _repository.CreateCompany(newCompany);

            var companyToReturnDTO = new CompanyToReturnDTO
            {
                CompanyId = company.Id,
                Notifications = schedule?.Notifications?.Select(n => n.SendingDate.ToString("dd/MM/yyyy")).ToList(),
            };

            return companyToReturnDTO;
        }

        public async Task<CompanyToReturnDTO> GetCompanyNotificationsByIdAsync(Guid id)
        {
            var company = await _repository.GetCompanyNotificationsByIdAsync(id);

            if (company == null)
            {
                return null;
            }

            var companyToReturnDTO = new CompanyToReturnDTO
            {
                CompanyId = company.Id,
                Notifications = company.Schedule?.Notifications?.Select(n => n.SendingDate.ToString("dd/MM/yyyy")).ToList(),
            };

            return companyToReturnDTO;
        }
    }
}
