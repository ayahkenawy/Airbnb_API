using System;
using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class PropertyImagesReadDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int? PropertyId { get; set; }
        [Required]
        public string AddedByUser { get; set; } = "";
        [Required]
        public string Image { get; set; } = "";
        [Required]
        public DateTime? Created { get; set; }
        [Required]
        public bool? Status { get; set; }




    }
}
