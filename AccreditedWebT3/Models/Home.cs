using DataAccessLayer.Models;
using Services.common.Item;

namespace AccreditedWebT3.Models
{
    public class Home
    {
        public string Category { get; set; }
        public List<ItemDto> CategoryItems { get; set; }        

    }
}
