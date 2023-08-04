using Core.Entities;
using Shared.DTOs;

namespace Core.Interfaces
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyByIdAsync(Guid id);
        Task<CompanyToReturnDTO> CreateCompanyAsync(AddCompanyDTO company);
    }
}
