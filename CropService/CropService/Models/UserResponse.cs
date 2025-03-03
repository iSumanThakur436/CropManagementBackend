namespace CropService.Models
{
    public class UserResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Role Role { get; set; }
    }

    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }  // "Farmer", "Dealer", "Admin"
    }
}
