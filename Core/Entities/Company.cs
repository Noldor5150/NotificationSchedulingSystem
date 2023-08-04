using Shared.Enums;

namespace Core.Entities
{
    public class Company
    {
        public Guid Id { get; set; }
        public string CompanyNumber { get; set; }
        public CompanyType CompanyType { get; set; }
        public Market Market { get; set; }
        public Schedule? Schedule { get; set; }
    }
}
