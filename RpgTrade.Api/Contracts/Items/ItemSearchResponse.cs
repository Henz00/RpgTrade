namespace RpgTrade.Api.Contracts.Items
{
    public sealed class ItemSearchResponse
    {
        public List<ItemSearchResultDto> Items { get; set; } = [];

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
