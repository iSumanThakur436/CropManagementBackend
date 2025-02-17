using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CropApiBackend.Models
{
    public class Notification
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        public string Message { get; set; }
        public bool IsRead { get; set; }= false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
