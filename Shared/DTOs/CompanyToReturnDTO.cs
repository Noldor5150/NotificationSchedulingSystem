namespace Shared.DTOs
{
    public class CompanyToReturnDTO
    {
        public Guid CompanyId { get; set; }
        public List<string>? Notifications { get; set; }
    }
}
