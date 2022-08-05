namespace API_Airbnb.Data.DTOs
{
    public class PropertyReviewsReadDTO
    {
        
        public int Id { get; set; }
  
        public int? PropertyId { get; set; }

        public string ReviewByUser { get; set; } = "";
    
        public int? BookingId { get; set; }

        public string Comment { get; set; } = "";
    
        public byte? Rating { get; set; }
      
        public DateTime? Created { get; set; }
     
        public DateTime? Modified { get; set; }
     
        public bool? Status { get; set; }
        
    }
}
