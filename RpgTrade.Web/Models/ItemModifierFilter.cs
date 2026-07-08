namespace RpgTrade.Web.Models
{
    public class ItemModifierFilter
    {
        public int ModifierDefinitionId { get; set; }
        public string Name { get; set; } = "";
        public double? Min { get; set; }
        public double? Max { get; set; }
    }
}
