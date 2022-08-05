namespace API_Airbnb.Data.DTOs
{
    public class PropertyImageChildDTO
    {
        public int Id { get; set; }

        public int? PropertyId { get; set; }

        public string AddedByUser { get; set; } = "";

        public string Image { get; set; } = "";
      
        public DateTime? Created { get; set; }
      
        public bool? Status { get; set; }
    }
}
