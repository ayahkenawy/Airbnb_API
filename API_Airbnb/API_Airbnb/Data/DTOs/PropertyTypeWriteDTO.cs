using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class PropertyTypeWriteDTO
    {
        [Required]
        public string Name { get; set; } = "";
        public string IconImage { get; set; } = "";
    }
}
