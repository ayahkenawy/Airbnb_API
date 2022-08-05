using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class BookingsDTO
    {
        [Required]
        public int? PropertyId { get; set; }
        [Required]
        public DateTime? CheckInDate { get; set; }
        [Required]
        public DateTime? CheckOutDate { get; set; }
        [Required]
        public decimal? PricePerStay { get; set; }
        [Required]
        public byte? RoomsCount { get; set; }
        [Required]
        public byte? GuestCount { get; set; }
        [Required]
        public byte ChildrenCount { get; set; } = 0;
    }
}
