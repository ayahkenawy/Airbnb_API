namespace API_Airbnb.Data.DTOs
{
    public class PropertyReadDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string UserId { get; set; } = "";

        public string Description { get; set; } = "";
      
        public int? PropertyTypeId { get; set; }
      
        public int? RoomTypeId { get; set; }
   
        public int? CategoryId { get; set; }

        //public int? SubcategoryId { get; set; }

        public int? CountryId { get; set; }
    
        public int? StateId { get; set; }

        public int? CityId { get; set; }

        public string Address { get; set; } = "";

        public string Latitude { get; set; } = "";

        public string Longitude { get; set; } = "";
  
        public byte? BedroomCount { get; set; }

        public byte? BedCount { get; set; }
       
        public byte? BathroomCount { get; set; }

        public byte? AccomodatesCount { get; set; }

        public bool? AvailabilityType { get; set; }

        public DateTime? StartDate { get; set; }
 
        public DateTime? EndDate { get; set; }

        public decimal? Price { get; set; }

        public int? CurrencyId { get; set; }

        public byte? PriceType { get; set; }

        public string MinimumStay { get; set; } = "";

        public byte? MinimumStayType { get; set; }

        public bool? RefundType { get; set; }

        public DateTime? Created { get; set; }
  
        public DateTime? Modified { get; set; }

        public bool? Status { get; set; }
       public string Url { get; set; } = "";
    }
}
