using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class ArUserDTO
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
       
        public DateTime? DateOfBirth { get; set; }
     
        public string FacebookId { get; set; }

        public string TwitterId { get; set; }

        public string About { get; set; }
   
    }
}
