using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Type
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(60)]
        public string Name { get; set; } = string.Empty;
    }
}
