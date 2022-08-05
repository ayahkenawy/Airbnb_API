namespace API_Airbnb.Data.DTOs
{
    public class BookingsReadDTO
    {
        public int Id { get; set; }
        public int? PropertyId { get; set; }
        public string UserId { get; set; } = "";
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        public decimal? PricePerDay { get; set; }
        public decimal? PricePerStay { get; set; }
        public decimal? TaxPaid { get; set; }
        public decimal? SiteFees { get; set; }
        public decimal? AmountPaid { get; set; }
        public bool? IsRefund { get; set; }
        public DateTime? CancelDate { get; set; }
        public decimal? RefundPaid { get; set; }
        public DateTime? BookingDate { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public bool? Status { get; set; }
        public byte? RoomsCount { get; set; }
        public byte? GuestCount { get; set; }
        public byte? ChildrenCount { get; set; }
    }
}
