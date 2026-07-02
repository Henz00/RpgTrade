using RpgTrade.Domain;

namespace RpgTrade.Api.Contracts.Items
{
    public sealed class ItemSearchRequest
    {
        public int? BaseTypeId { get; set; }
        public ItemRarity? Rarity { get; set; }

        public List<ModifierFilterRequest> ModifierFilters { get; set; } = [];

        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
