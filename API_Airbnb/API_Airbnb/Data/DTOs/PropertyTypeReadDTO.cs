namespace API_Airbnb.Data.DTOs
{
    public class PropertyTypeReadDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string IconImage { get; set; } = "";
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool? Status { get; set; }
    }
}
