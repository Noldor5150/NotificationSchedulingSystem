using Shared.DTOs;

namespace Core.Interfaces
{
    public interface ICompanyService
    {
        Task<CompanyToReturnDTO> CreateCompanyAsync(AddCompanyDTO company);
        Task<CompanyToReturnDTO> GetCompanyNotificationsByIdAsync(Guid id);
    }
}
