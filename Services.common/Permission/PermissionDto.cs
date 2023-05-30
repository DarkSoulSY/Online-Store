using System.ComponentModel.DataAnnotations;

namespace Services.common.Permission
{
    public class PermissionDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
