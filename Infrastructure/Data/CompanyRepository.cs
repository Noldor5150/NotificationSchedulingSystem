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

        public async Task CreateCompany(Company company)
        {
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<Company>> GetCompaniesAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetCompanyByIdAsync(Guid id)
        {
            return await _context.Companies.FindAsync(id);
        }
    }
}
