using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class ChangePasswordDTO
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
    }
}
