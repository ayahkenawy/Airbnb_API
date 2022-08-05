namespace API_Airbnb.Data.DTOs
{
    public class PropertyReviewsDTO
    {
        public int? PropertyId { get; set; }

        public int? BookingId { get; set; }

        public string Comment { get; set; } = "";

        public byte? Rating { get; set; }
    }
}
