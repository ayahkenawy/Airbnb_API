

namespace API_Airbnb.Data.DTOs
{
    public class PromoCodeTransDTO
    {


        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Code { get; set; } = "";

        public decimal? Discount { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public bool? Status { get; set; }

        public virtual ICollection<ArTransactionsChildReadDTO> ArTransactions { get; set; }

    }
    
}
