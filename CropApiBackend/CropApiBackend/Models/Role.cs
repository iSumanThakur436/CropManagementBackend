using System.ComponentModel.DataAnnotations;

namespace CropApiBackend.Models
{
    public class Role
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
