using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class DisputeDTO
    {
        
        [Required]
        public int? PropertyId { get; set; }
        [Required]
        public int? BookingId { get; set; }
        [Required]

        public string Title { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";
   
    }
}
