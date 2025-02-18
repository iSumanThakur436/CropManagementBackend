using System.ComponentModel.DataAnnotations;

namespace CropApiBackend.Models
{
    public class Role
    {
        [Required]
        public required string Id { get; set; }
        [Required]
        public required string RoleName { get; set; }
    }
}
