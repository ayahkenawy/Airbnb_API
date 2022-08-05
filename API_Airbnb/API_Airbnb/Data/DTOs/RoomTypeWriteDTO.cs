using System.ComponentModel.DataAnnotations;

namespace API_Airbnb.Data.DTOs
{
    public class RoomTypeWriteDTO
    {
        [Required]
        public string Name { get; set; } = "";
        public string IconImage { get; set; } = "";
    }
}
