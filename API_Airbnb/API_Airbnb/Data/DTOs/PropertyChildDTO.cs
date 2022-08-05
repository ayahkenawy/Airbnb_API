namespace API_Airbnb.Data.DTOs
{
    public class PropertyChildDTO
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


        public virtual ICollection<PropertyImageChildDTO> ArPropertyImages { get; set; } = new HashSet<PropertyImageChildDTO>();

        public virtual ICollection<PropertyReviewsChildDTO> ArPropertyReviews { get; set; } = new HashSet<PropertyReviewsChildDTO>();
        public virtual ICollection<ArTransactionsChildReadDTO> ArTransactions { get; set; } = new HashSet<ArTransactionsChildReadDTO>();
        public virtual ICollection<BookingsReadDTO> ArBookings { get; set; } = new HashSet<BookingsReadDTO>();

        public virtual ICollection<DisputeReadDTO> ArDisputes { get; set; } = new HashSet<DisputeReadDTO>();


        public virtual CategoriesReadDTO? Category { get; set; } 

        public virtual CityReadDTO? City { get; set; } 

        public virtual CountryReadDTO? Country { get; set; }

        public virtual ArCurrenciesChildReadDTO? Currency { get; set; } 

        public virtual PropertyTypeReadDTO? PropertyType { get; set; } 

        public virtual RoomTypeReadDTO? RoomType { get; set; } 


        //public virtual SubcategoriesReadDTO? Subcaregory { get; set; }
        public virtual ArUserDTO? User { get; set; }

    }
}
