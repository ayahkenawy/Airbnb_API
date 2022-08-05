namespace API_Airbnb.Data.DTOs
{
    public class CountryReadDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";
   
        public string Code { get; set; }

        public bool? Status { get; set; }
    }
}
