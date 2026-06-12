namespace RpgTrade.Api.Contracts.Items
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Rarity { get; set; } = string.Empty;
        public int ItemLevel { get; set; }
        public string BaseType { get; set; } = string.Empty;
        public string ItemClass { get; set; } = string.Empty;
        public List<ItemModifierDto> Modifiers { get; set; } = [];
    }
}
