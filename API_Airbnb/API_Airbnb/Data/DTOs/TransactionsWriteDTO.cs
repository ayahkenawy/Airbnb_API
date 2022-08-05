using System;
using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class TransactionsWriteDTO
    {
        [Required]
        public int? PropertyId { get; set; }
        [Required]
        public string RecieverId { get; set; } = "";
        [Required]
        public int? BookingId { get; set; }
        [Required]
        public decimal? SiteFrees { get; set; }
        [Required]
        public decimal? Amount { get; set; }
        [Required]
        public decimal? TransferOn { get; set; }
        [Required]
        public int? CurrencyId { get; set; }
        [Required]
        public int? PromoCodeId { get; set; }
        [Required]
        public decimal? DiscoundAmt { get; set; }





    }

}

