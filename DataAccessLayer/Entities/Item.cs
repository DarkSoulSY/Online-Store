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
    public class Item
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<ItemSizePrice> ItemSizePrices { get; set; }
        public Type Type { get; set; }
        public int TypeId { get; set; }
    }
}
