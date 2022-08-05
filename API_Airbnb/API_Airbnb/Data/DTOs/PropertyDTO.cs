using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class PropertyDTO
    {
        [Required]
        public string Name { get; set; } = "";
      
        [Required]
        public string Description { get; set; } = "";
        [Required]
        public int? PropertyTypeId { get; set; }
        [Required]
        public int? RoomTypeId { get; set; }
        [Required]
        public int? CategoryId { get; set; }
       
        //public int? SubcategoryId { get; set; }
        [Required]
        public int? CountryId { get; set; }
    
      //  public int? StateId { get; set; }
        [Required]
        public int? CityId { get; set; }
        [Required]
        public string Address { get; set; } = "";

        public string Latitude { get; set; } = "";

        public string Longitude { get; set; } = "";
        [Required]
        public byte? BedroomCount { get; set; }
        [Required]
        public byte? BedCount { get; set; }
        [Required]
        public byte? BathroomCount { get; set; }
        [Required]
        public byte? AccomodatesCount { get; set; }
        
        public bool? AvailabilityType { get; set; }
    
        //public DateTime? StartDate { get; set; }

        //public DateTime? EndDate { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int? CurrencyId { get; set; }

        public byte? PriceType { get; set; }


        public string MinimumStay { get; set; } = "";
  
        public byte? MinimumStayType { get; set; }
      
        public bool? RefundType { get; set; }
        public string Url { get; set; } = "";
     
    }
}
