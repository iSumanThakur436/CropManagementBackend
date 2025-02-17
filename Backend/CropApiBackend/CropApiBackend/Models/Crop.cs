using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CropApiBackend.Models
{
    public class Crop
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string FarmerId { get; set; }
        [ForeignKey("FarmerId")]
        public User Farmer { get; set;}
        [Required]
        public string CropType { get; set; }
        [Required]
        public int Quantity { get; set; } //in kg
        [Required]
        public decimal PricePerKg { get; set; }
        [Required]
        public string Status { get; set; } = "Available";
        public DateTime CreatedAt { get; set; }= DateTime.Now;

    }
}
