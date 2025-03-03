using System;

namespace CropService.Models
{
    public class Crop
    {
        public Guid Id { get; set; }
        public Guid FarmerId { get; set; }  // User who listed the crop
        public string CropType { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerKg { get; set; }
        public string Location { get; set; }
        public string Status { get; set; } = "Available"; // "Available" or "Sold"
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
