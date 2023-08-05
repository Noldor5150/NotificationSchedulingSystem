
namespace Core.Interfaces
{
    public interface ICompanyNumberDublicateCheckService
    {
        Task<bool> CheckCompanyNumberlExistsAsync(string companyNumber);
    }
}
