using Shared.Enums;

namespace Shared.DTOs
{
    public class AddCompanyDTO
    {
        public Guid Id { get; set; }
        public string CompanyNumber { get; set; }
        public CompanyType CompanyType { get; set; }
        public Market Market { get; set; }
    }
}
