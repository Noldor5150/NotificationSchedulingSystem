using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CompanyRepository : ICompanyRepository
    {

        private readonly CompanyContext _context;

        public CompanyRepository(CompanyContext context) 
        {
            _context = context;
        }

        public async Task<Company> GetCompanyNotificationsByIdAsync(Guid id)
        {
            return await _context.Companies.Include(c => c.Schedule).ThenInclude(s => s.Notifications).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> CheckCompanyNumberlExistsAsync(string companyNumber)
        {
            return await _context.Companies.AnyAsync(c => c.CompanyNumber == companyNumber);
        }

        public async Task CreateCompany(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }
    }
}
