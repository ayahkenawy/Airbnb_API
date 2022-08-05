namespace API_Airbnb.Data.DTOs
{
    public class ArTransactionsChildReadDTO
    {
        public int Id { get; set; }

        public int? PropertyId { get; set; }


        public string RecieverId { get; set; }

        public int? BookingId { get; set; }

        public decimal? SiteFrees { get; set; }

        public decimal? Amount { get; set; }

        public decimal? TransferOn { get; set; }

        public int? CurrencyId { get; set; }

        public int? PromoCodeId { get; set; }

        public decimal? DiscoundAmt { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool? Status { get; set; }
    }
}
