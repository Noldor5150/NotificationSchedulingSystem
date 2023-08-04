using Core.Entities;

namespace Core.Interfaces
{
    public interface ICompanyRepository
    {
        Task <Company> GetCompanyByIdAsync(Guid id);
        Task<IReadOnlyList<Company>> GetCompaniesAsync();
        Task CreateCompany(Company company);
    }
}
