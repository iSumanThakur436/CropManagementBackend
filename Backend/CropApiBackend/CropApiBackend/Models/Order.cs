using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CropApiBackend.Models
{
    public class Order
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string DealerId { get; set; }

        [ForeignKey("DealerId")]
        public User Dealer { get; set; }

        [Required]
        public string FarmerId { get; set; }

        [ForeignKey("FarmerId")]
        public User Farmer { get; set; }

        [Required]
        public string CropId { get; set; }

        [ForeignKey("CropId")]
        public Crop Crop { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        [Required]
        public string Status { get; set; } = "Pending"; // Pending / Completed

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
