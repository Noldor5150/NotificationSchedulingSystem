using Core.Interfaces;


namespace Core.Services
{
    public class CompanyNumberDublicateCheckService : ICompanyNumberDublicateCheckService
    {
        private readonly ICompanyRepository _repository; 
        public CompanyNumberDublicateCheckService(ICompanyRepository repository)
        {
            _repository = repository;
        }
        public async Task<bool> CheckCompanyNumberlExistsAsync(string companyNumber)
        {
            return await _repository.CheckCompanyNumberlExistsAsync(companyNumber);
        }
    }
}
