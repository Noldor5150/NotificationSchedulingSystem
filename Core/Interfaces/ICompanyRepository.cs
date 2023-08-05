using Core.Entities;

namespace Core.Interfaces
{
    public interface ICompanyRepository
    {
        Task CreateCompany(Company company);
        Task<bool> CheckCompanyNumberlExistsAsync(string companyNumber);
        Task<Company> GetCompanyNotificationsByIdAsync(Guid id);
    }
}
