using Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace Shared.DTOs
{
    public class AddCompanyDTO
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Company number numeric must be and exact 10 digits to contain")]
        public string CompanyNumber { get; set; }

        [Required]
        [Range(0, 2, ErrorMessage = "Company type between 0 and 2 must be ")]
        public CompanyType CompanyType { get; set; }

        [Required]
        [Range(0, 3, ErrorMessage = "Company type between 0 and 3 must be ")]
        public Market Market { get; set; }
    }
}
