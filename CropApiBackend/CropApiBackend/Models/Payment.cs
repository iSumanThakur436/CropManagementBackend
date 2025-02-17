using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CropApiBackend.Models
{
    public class Payment
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        [Required]
        public string RazorpayId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;


    }
}
