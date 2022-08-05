namespace API_Airbnb.Data.DTOs
{
    public class DisputeReadDTO
    {
        public int Id { get; set; }
        public int? PropertyId { get; set; }
    
        public int? BookingId { get; set; }
        public string UserId { get; set; } = "";

        public string Title { get; set; } = "";
     
        public string Description { get; set; } = "";
        public DateTime? Created { get; set; }
      
        public DateTime? Modified { get; set; }

        public bool? Status { get; set; }
    }
}
