using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CropApiBackend.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string RoleId { get; set; }
        [ForeignKey("RoleId")]
        public Role Role { get; set; }
        public DateTime CreatedAt { get; set; }= DateTime.Now;


    }
}
