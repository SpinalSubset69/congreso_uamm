using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RegisterRepportuerDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [RegularExpression(@"\d{10}", ErrorMessage= ("Phone must be only Numbers and 10 digits"))]
        public string Phone { get; set; }
        public string Biography { get; set; }
        [Required]
        public int? ActivityId { get; set; }
    }
}