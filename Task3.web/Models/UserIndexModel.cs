using Services.common.User;

namespace Task3.web.Models
{
    public class UserIndexModel 
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
