using RpgTrade.Domain;

namespace RpgTrade.Api.Contracts.Items
{
    public sealed class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ItemRarity Rarity { get; set; }
        public int ItemLevel { get; set; }
        public string BaseTypeName { get; set; } = string.Empty;
        public string ItemClassName { get; set; } = string.Empty;
        public List<ItemModifierDto> Modifiers { get; set; } = [];
    }
}
