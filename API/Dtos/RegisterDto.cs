using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

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
        public string Career { get; set; }
        [Required]
        public int? ActivityId { get; set; }
    }
}