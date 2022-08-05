using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class SubcategoriesReadDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";
        [Required]
        public DateTime? Created { get; set; }
        [Required]
        public DateTime? Modified { get; set; }
        [Required]
        public bool? Status { get; set; }


    }
}
