using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CropApiBackend.Models
{
    public class Subscription
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string DealerId { get; set; }
        [ForeignKey("DealerId")]
        public User Dealer { get; set; }
        [Required]
        public string CropType { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;

    }
}
