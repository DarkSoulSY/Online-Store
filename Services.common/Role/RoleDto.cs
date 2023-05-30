
using System.ComponentModel.DataAnnotations;

namespace Services.common.Role
{
    public class RoleDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
