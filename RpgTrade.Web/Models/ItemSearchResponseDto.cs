namespace RpgTrade.Web.Models
{
    public class ItemSearchResponseDto
    {
        public List<ItemDto> Items { get; set; } = [];
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
