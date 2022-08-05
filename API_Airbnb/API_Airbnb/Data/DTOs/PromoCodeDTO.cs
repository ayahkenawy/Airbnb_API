using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class PromoCodeDTO
    {
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public string? Code { get; set; }
        [Required]
        public decimal? Discount { get; set; }
    }
}
