using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class CategoryWriteDTO
    {
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Description { get; set; } = "";
    }
}
