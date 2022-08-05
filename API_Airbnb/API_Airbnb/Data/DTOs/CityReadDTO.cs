namespace API_Airbnb.Data.DTOs
{
    public class CityReadDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";
      
        public bool? Status { get; set; }
      
        public int? CountryId { get; set; }
    }
}
