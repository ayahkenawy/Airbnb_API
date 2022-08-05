using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class CategoriesReadDTO
    {
        [Required]
        public int Id { get; set; }
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

        public virtual ICollection<SubcategoriesReadDTO>? ArSubcategories { get; set; }



    }
}
