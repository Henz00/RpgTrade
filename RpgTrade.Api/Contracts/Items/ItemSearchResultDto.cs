using RpgTrade.Domain;

namespace RpgTrade.Api.Contracts.Items
{
    public sealed class ItemSearchResultDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public ItemRarity Rarity { get; set; }

        public int BaseTypeId { get; set; }
        public string BaseTypeName { get; set; } = string.Empty;

        public int ItemLevel { get; set; }

        public List<ItemModifierDto> Modifiers { get; set; } = [];
    }
}
