using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class EmailUserDataDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
    }
}