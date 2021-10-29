using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace API.Dtos
{
    public class StudentRegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"([a])\d+", ErrorMessage = "Insert a Valid Student Number")]
        public string StudentNumber { get; set; }
        public string phone {get; set;}
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string RegisterAt { get; set; }
        [Required]
        public string Career { get; set; }
        [Required]
        public string Day { get; set; }
        [Required]
        public string Hour { get; set; }
        [Required]
        public bool IsRegister { get; set; }
        [Required]
        public string Activity { get; set; }
    }
}