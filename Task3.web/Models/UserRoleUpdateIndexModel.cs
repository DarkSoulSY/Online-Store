using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Task3.web.Models
{
    public class UserRoleUpdateIndexModel
    {
        public int Id { get; set; }
        public string SelectedRole { get; set; }
        public string SelectedUsername { get; set; }
        public List<SelectListItem> RoleNames { get; set; } 
        public List<SelectListItem> Usernames { get; set; }
    }
}
