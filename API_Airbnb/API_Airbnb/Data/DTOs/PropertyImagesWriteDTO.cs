using System;
using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class PropertyImagesWriteDTO
    {

        [Required]
        public int? PropertyId { get; set; }
    
        [Required]
        public string Image { get; set; } = "";
     
    }
}
