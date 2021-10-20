using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"([a])\d+", ErrorMessage = "Insert a Valid Student Number")]
        public string StudentNumber {get; set;}
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string RegisterAt { get; set; }
        [Required]
        public string CareerId { get; set; }
        [Required]
        public string ActivityId { get; set; }
    }
}