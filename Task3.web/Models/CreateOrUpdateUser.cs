namespace Task3.web.Models
{
    public class CreateOrUpdateUser
    {
        public int? Id { get; set; }
        public string Username { get; set; } 
        public string PhoneNumber { get; set; } 
        public string? Address { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; } 
    }
}
