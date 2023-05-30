using Services.common.SizePrice;

namespace Services.common.Item
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public string PictureURL { get; set; }
        public List<SizePriceDto>? SizePrice { get; set; }
        
    }
}
