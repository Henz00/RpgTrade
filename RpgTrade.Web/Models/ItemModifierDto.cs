namespace RpgTrade.Web.Models
{
    public class ItemModifierDto
    {
        public int ModifierDefinitionId { get; set; }
        public string Name { get; set; } = string.Empty;

        public double Value { get; set; }
    }
}
