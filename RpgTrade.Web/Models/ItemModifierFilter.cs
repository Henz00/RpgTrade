namespace RpgTrade.Web.Models
{
    public class ItemModifierFilter
    {
        public int ModifierDefinitionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Min { get; set; }
        public int? Max { get; set; }
    }
}
