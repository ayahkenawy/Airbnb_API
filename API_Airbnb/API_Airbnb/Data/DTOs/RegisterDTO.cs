using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public bool? UserType { get; set; }

    }
}
