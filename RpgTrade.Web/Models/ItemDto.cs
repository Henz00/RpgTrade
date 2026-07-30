using System.Security.AccessControl;

namespace RpgTrade.Web.Models
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Rarity { get; set; } = string.Empty;
        public int BaseTypeId { get; set; }
        public string BaseTypeName { get; set; } = string.Empty;
        public int ItemLevel { get; set; }
        public string ItemClassName { get; set; } = string.Empty;
        public List<ItemModifierDto> Modifiers { get; set; } = [];
    }
}
